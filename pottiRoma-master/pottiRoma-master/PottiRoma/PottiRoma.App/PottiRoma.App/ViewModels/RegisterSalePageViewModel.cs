using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.Challenges;
using PottiRoma.App.Models.Responses.GamificationPoints;
using PottiRoma.App.Models.Responses.Sales;
using PottiRoma.App.Models.Responses.Seasons;
using PottiRoma.App.Models.Responses.Trophies;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RegisterSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISalesAppService _salesAppService;
        private readonly IUserAppService _userAppService;
        private readonly ITrophyAppService _trophyAppService;
        private readonly IChallengesAppService _challengesAppService;
        private readonly ISeasonAppService _seasonAppService;
        private readonly IGamificationPointsAppService _gamificationPointsAppService;

        private User CurrentUser;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand SaveSaleCommand { get; set; }

        private Sale _saleRegistered;
        public Sale SaleRegistered
        {
            get { return _saleRegistered; }
            set { SetProperty(ref _saleRegistered, value); }
        }

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
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
            IUserAppService userAppService,
            IGamificationPointsAppService gamificationPointsAppService,
            ITrophyAppService trophyAppService,
            IChallengesAppService challengesAppService,
            ISeasonAppService seasonAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _salesAppService = salesAppService;
            _userAppService = userAppService;
            _trophyAppService = trophyAppService;
            _gamificationPointsAppService = gamificationPointsAppService;
            _challengesAppService = challengesAppService;
            _seasonAppService = seasonAppService;
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
            base.OnNavigatingTo(parameters);
        }

        private bool IsSaleValid()
        {
            return (SaleRegistered.SaleValue > 0 && SaleRegistered.SalePaidValue >= 0) && (SaleRegistered.ClienteId != null) ? true : false;
        }

        private async Task<GetSalesByUserIdResponse> SaveNewSaleInCache()
        {
            var sales = new GetSalesByUserIdResponse();
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                sales = await _salesAppService.GetSalesByUserId(user.UsuarioId.ToString());
                await CacheAccess.Insert<List<Sale>>(CacheKeys.SALES, sales.Sales);
            }
            catch
            { }
            return sales;
        }

        private async void SaveSale()
        {
            TimeSpan duration = new TimeSpan(0, 0, 3);

            if (IsSaleValid())
            {
                await NavigationHelper.ShowLoading();
                if (!_isEditSale)
                {
                    CanExecuteInitial();
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
                        var userSales = await SaveNewSaleInCache();
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

                        GetGamificationPointsResponse currentPoints = new GetGamificationPointsResponse();
                        try
                        {
                            currentPoints.Entity = await CacheAccess.GetSecure<Points>(CacheKeys.POINTS);
                        }
                        catch
                        {
                            currentPoints = await _gamificationPointsAppService.GetCurrentGamificationPoints();
                            await CacheAccess.InsertSecure<Points>(CacheKeys.POINTS, currentPoints.Entity);
                        }
                        user.AverageItensPerSalePoints = AverageItensPerSale;
                        user.AverageTicketPoints += AverageTicketPoints;
                        user.SalesNumberPoints += (int)currentPoints.Entity.SalesNumber;

                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            UsuarioId = userGuid,
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            SalesNumberPoints = user.SalesNumberPoints
                        });
                        await GetParametersForChallenge();
                        if (!_hasWonTrophy)
                            UserDialogs.Instance.Toast("Parabéns! Você ganhou " + currentPoints.Entity.SalesNumber + " Sementes com essa Venda!", duration);
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
                        var userSales = await SaveNewSaleInCache();
                        _userDialogs.Toast("Venda Editada com sucesso!");
                    }
                    catch
                    {
                        _userDialogs.Toast("Não foi possível editar sua venda!");
                    }
                    finally
                    {
                        await NavigationHelper.PopLoading();
                        await _navigationService.GoBackAsync();      
                    }
                }
            }
            else _userDialogs.Toast("Faltam Dados para preencher!", duration);
        }

        private bool _hasWonTrophy = false;
        private async Task GetParametersForChallenge()
        {
            var user = new User();
            var currentSeasonReponse = new SeasonResponse();
            var currentChallenges = new GetCurrentChallengesResponse();
            var myTrophies = new GetThophiesByUserIdResponse();
            user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
            try
            {
                currentSeasonReponse = await _seasonAppService.CurrentSeason();
                currentChallenges = await _challengesAppService.GetCurrentChallenges(currentSeasonReponse.Entity.TemporadaId.ToString());
                myTrophies = await _trophyAppService.GetCurrentTrophies(user.UsuarioId.ToString());
            }
            catch
            {}
            await CheckSaleChallengeCompleted(myTrophies.Trophies, user.UsuarioId.ToString(), currentChallenges.Challenges, currentSeasonReponse.Entity);
        }

        private async Task CheckSaleChallengeCompleted(List<Trophy> myTrophies, string usuarioId, List<Challenge> currentChallenges, Season CurrentSeason)
        {
            try
            {
                int myRSalesPoints = 0;
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

                try
                {
                    myRSalesPoints = await CacheAccess.Get<int>(CacheKeys.SALE_POINTS_FOR_CHALLENGE);
                }
                catch
                {
                    myRSalesPoints = await _salesAppService.GetUserSalePointsForChallenge(usuarioId);
                    await CacheAccess.Insert<int>(CacheKeys.SALE_POINTS_FOR_CHALLENGE, myRSalesPoints);
                }

                foreach (var challenge in currentChallenges)
                {
                    bool _hasTrophy = false;
                    bool _hasEnoughtPoints = false;
                    if (challenge.Parameter == 1)
                    {
                        foreach (var trophy in myTrophies)
                        {
                            if (trophy.DesafioId.ToString() == challenge.DesafioId.ToString())
                            {
                                _hasTrophy = true;
                                break;
                            }
                        }
                        _hasEnoughtPoints = (myRSalesPoints >= challenge.Goal) ? true : false;
                    }
                    if (!_hasTrophy && _hasEnoughtPoints)
                    {
                        await _trophyAppService.InsertNewTrophy(new InsertTrophyRequest
                        {
                            DesafioId = challenge.DesafioId,
                            EndDate = challenge.EndDate,
                            StartDate = challenge.StartDate,
                            Goal = challenge.Goal,
                            Name = challenge.Name,
                            Parameter = challenge.Parameter,
                            TemporadaId = CurrentSeason.TemporadaId,
                            UsuarioId = new Guid(usuarioId),
                            Prize = challenge.Prize
                        });
                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            SalesNumberPoints = user.SalesNumberPoints + challenge.Prize,
                            UsuarioId = user.UsuarioId
                        });
                        _hasWonTrophy = true;
                        UserDialogs.Instance.Toast("Você acabou de ganhar um Troféu de Vendas Realizadas! Parabéns!", new TimeSpan(0, 0, 4));
                    }
                }
            }
            catch { }

        }


        private async void GoBack()
        {
            CanExecuteInitial();
            await _navigationService.GoBackAsync();
            CanExecuteEnd();
        }
    }
}
