﻿using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RegisterSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISalesAppService _salesAppService;
        private readonly IUserAppService _userAppService;

        private User CurrentUser;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand SaveSaleCommand { get; set; }

        private Sale _saleRegistered;
        public Sale SaleRegistered
        {
            get { return _saleRegistered; }
            set { SetProperty(ref _saleRegistered, value); }
        }

        private string _nameAndDateLabel;
        public string NameAndDateLabel
        {
            get { return _nameAndDateLabel; }
            set { SetProperty(ref _nameAndDateLabel, value); }
        }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private bool _descriptionPlaceHolderVisible = true;
        public bool DescriptionPlaceHolderVisible
        {
            get { return _descriptionPlaceHolderVisible; }
            set { SetProperty(ref _descriptionPlaceHolderVisible, value); }
        }

        public bool _isEditSale = false;

        public RegisterSalePageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            ISalesAppService salesAppService,
            IUserAppService userAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _salesAppService = salesAppService;
            _userAppService = userAppService;
            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
            SaveSaleCommand = new DelegateCommand(SaveSale).ObservesCanExecute(() => CanExecute);
            SaleRegistered = new Sale();
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigationKeyParameters.SelectedSale))
            {
                ButtonText = "EDITAR VENDA";
                SaleRegistered = parameters[NavigationKeyParameters.SelectedSale] as Sale;
                NameAndDateLabel = "Venda para: " + SaleRegistered.ClientName + ", " + Formatter.FormatDate(SaleRegistered.SaleDate);
                _isEditSale = true;
            }
            else if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
            {
                ButtonText = "SALVAR VENDA";
                Client selectedClient = (Client)parameters[NavigationKeyParameters.SelectedClient];
                SaleRegistered.ClienteId = selectedClient.ClienteId;
                SaleRegistered.ClientName = selectedClient.Name;
                _isEditSale = false;

                try
                {
                    CurrentUser = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    SaleRegistered.UsuarioId = CurrentUser.UsuarioId;
                }
                catch
                {
                    _userDialogs.Toast("Tivemos um problema com seu usuário, faça o Login novamente!");
                }
                NameAndDateLabel = "Venda para: " + SaleRegistered.ClientName + ", " + Formatter.FormatDate(DateTime.Now);
            }
            if(SaleRegistered != null && SaleRegistered.Description != null)
                DescriptionPlaceHolderVisible = (SaleRegistered.Description.Length > 0) ? false : true;
            base.OnNavigatedTo(parameters);
        }

        private bool IsSaleValid()
        {
            return (SaleRegistered.SaleValue > 0 && SaleRegistered.SalePaidValue >= 0) && (SaleRegistered.ClienteId != null) ? true : false;
        }

        private async void SaveSale()
        {
            TimeSpan duration = new TimeSpan(0, 0, 3);

            if (IsSaleValid())
            {
                if (!_isEditSale)
                {
                    CanExecuteInitial();
                    await NavigationHelper.ShowLoading();
                    try
                    {
                        var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                        var userGuid = user.UsuarioId;

                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RegisterSalePage, InsightsActionNames.SaveSale }
                        });

                        await _salesAppService.InsertNewSale(new InsertNewSaleRequest
                        {
                            UsuarioId = userGuid,
                            UserName = user.Name,
                            ClienteId = SaleRegistered.ClienteId,
                            ClientName = SaleRegistered.ClientName,
                            NumberSoldPieces = SaleRegistered.NumberSoldPieces,
                            SaleDate = DateTime.Now,
                            SalePaidValue = SaleRegistered.SalePaidValue,
                            SaleValue = SaleRegistered.SaleValue,
                            Description = SaleRegistered.Description
                        });

                        var userSales = await _salesAppService.GetSalesByUserId(user.UsuarioId.ToString());
                        float salesValue = 0;
                        int salesCount = 0;
                        int salesNumberPieces = 0;
                        foreach (var sale in userSales.Sales)
                        {
                            salesValue += sale.SaleValue;
                            salesNumberPieces += sale.NumberSoldPieces;
                            salesCount++;
                        }
                        int AverageTicketPoints = (int)salesValue / salesCount;
                        int AverageItensPerSale = salesNumberPieces / salesCount;

                        var points = await CacheAccess.GetSecure<Points>(CacheKeys.POINTS);
                        user.AverageItensPerSalePoints = AverageItensPerSale;
                        user.AverageTicketPoints += AverageTicketPoints;
                        user.SalesNumberPoints += (int)points.SalesNumber;

                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            UsuarioId = userGuid,
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            SalesNumberPoints = user.SalesNumberPoints
                        });
                        UserDialogs.Instance.Toast("Parabéns! Você ganhou " + points.SalesNumber + " Pontos com essa Venda!", duration);
                        await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                    }
                    catch
                    {
                        _userDialogs.Toast("Não foi possível registrar sua venda");
                    }
                    finally
                    {
                        CanExecuteEnd();
                        await NavigationHelper.PopLoading();
                    }
                }
                else
                {
                    try
                    {
                        await _salesAppService.UpdateSale(SaleRegistered.VendaId.ToString(), SaleRegistered.SaleValue, SaleRegistered.SalePaidValue, SaleRegistered.NumberSoldPieces, SaleRegistered.Description);
                        _userDialogs.Toast("Venda Editada com sucesso!");
                    }
                    catch
                    {
                        _userDialogs.Toast("Não foi possível editar sua venda!");
                    }
                    finally
                    {
                        await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                    }
                }
            }
            else _userDialogs.Toast("Faltam Dados para preencher!", duration);
        }

        private async void GoBack()
        {
            CanExecuteInitial();
            await _navigationService.GoBackAsync();
            CanExecuteEnd();
        }
    }
}
