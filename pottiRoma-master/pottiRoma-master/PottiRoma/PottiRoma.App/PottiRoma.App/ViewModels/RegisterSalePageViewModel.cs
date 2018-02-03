using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RegisterSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISalesAppService _salesAppService;

        private InsertNewSaleRequest SaleInsertedRequest;
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

        public RegisterSalePageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            ISalesAppService salesAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _salesAppService = salesAppService;
            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
            SaveSaleCommand = new DelegateCommand(SaveSale).ObservesCanExecute(() => CanExecute);
            SaleRegistered = new Sale();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
            {
                Client selectedClient = (Client)parameters[NavigationKeyParameters.SelectedClient];
                SaleRegistered.ClienteId = selectedClient.ClienteId;
                SaleRegistered.ClientName = selectedClient.Name;

                try
                {
                    CurrentUser = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    SaleRegistered.UsuarioId = CurrentUser.UsuarioId;
                }
                catch
                {
                    _userDialogs.Toast("Seu usuário foi removido, contate o administrador");
                }


                NameAndDateLabel = "Venda para: " + SaleRegistered.ClientName + ", " + Formatter.FormatDate(DateTime.Now);
            }
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
                CanExecuteInitial();
                await NavigationHelper.ShowLoading();
                try
                {
                    var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    var userGuid = user.UsuarioId;

                    var teste1 = userGuid.ToString();
                    var teste2 = user.Name;
                    var teste3 = SaleRegistered.ClienteId.ToString();
                    var teste4 = SaleRegistered.ClientName;
                    var teste5 = SaleRegistered.SaleDate.ToString();
                    var teste6 = SaleRegistered.SalePaidValue;
                    var teste7 = SaleRegistered.SaleValue;

                    await _salesAppService.InsertNewSale(new InsertNewSaleRequest
                    {
                        UsuarioId = userGuid,
                        UserName = user.Name,
                        ClienteId = SaleRegistered.ClienteId,
                        ClientName = SaleRegistered.ClientName,
                        NumberSoldPieces = SaleRegistered.NumberSoldPieces,
                        SaleDate = SaleRegistered.SaleDate,
                        SalePaidValue = SaleRegistered.SalePaidValue,
                        SaleValue = SaleRegistered.SaleValue
                    });
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
