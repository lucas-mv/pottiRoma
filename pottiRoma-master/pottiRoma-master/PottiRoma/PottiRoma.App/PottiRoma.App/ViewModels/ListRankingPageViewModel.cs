using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Responses.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Enums;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class ListRankingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IUserAppService _userAppService;
        private CarouselBannerType ListType;
        private ObservableCollection<User> _appUsers;
        public ObservableCollection<User> AppUsers
        {
            get { return _appUsers; }
            set { SetProperty(ref _appUsers, value); }
        }

        private User _thisUser;
        public User ThisUser
        {
            get { return _thisUser; }
            set { SetProperty(ref _thisUser, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ListRankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            IUserAppService userAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _userAppService = userAppService;

            AppUsers = new ObservableCollection<User>();
        }

        private void InsertPageTitleAndPoints()
        {
            switch (ListType)
            {
                case CarouselBannerType.AverageTicket:
                    Title = "Ticket Médio";
                    foreach (var users in AppUsers)
                    users.TotalPoints = users.AverageTicketPoints;
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                    {
                        { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingAverageTicket }
                    });
                    break;
                case CarouselBannerType.RegisterClients:
                    Title = "Cadastro de Clientes";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.RegisterClientsPoints;
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                    {
                        { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingRegisterClients }
                    });
                    break;
                case CarouselBannerType.AveragePiecesForSale:
                    Title = "Peças por Venda";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.AverageItensPerSalePoints;
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                    {
                        { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingPiecesForSale }
                    });
                    break;
                case CarouselBannerType.RegisterAlliedFlowers:
                    Title = "Convite de Flores Aliadas";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.InviteAllyFlowersPoints;
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                    {
                        { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingInviteFlowers }
                    });
                    break;
                case CarouselBannerType.RegisteredSales:
                    Title = "Registro de Vendas";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.SalesNumberPoints;
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                    {
                        { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingPiecesForSale }
                    });
                    break;
                case CarouselBannerType.Total:
                    Title = "Geral";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.AverageItensPerSalePoints + users.AverageTicketPoints + users.RegisterClientsPoints + users.InviteAllyFlowersPoints + users.SalesNumberPoints;
                    break;
            }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigationKeyParameters.RankingType))
                ListType = (CarouselBannerType)parameters[NavigationKeyParameters.RankingType];
            else ListType = CarouselBannerType.Total;
            await GetAppUsers();
            base.OnNavigatedTo(parameters);
            await NavigationHelper.PopLoading();
        }

        private async Task GetAppUsers()
        {
            AppUsers.Clear();
            try
            {
                var users = await _userAppService.GetAppUsers();
                
                foreach (var user in users.Users)
                {
                    AppUsers.Add(user);
                }

            }
            catch
            {
                _userDialogs.Toast("Não foi possível obter os usuários");
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }

            var listaOrdenada = ListaOrdenada();

            AppUsers.Clear();
            

            foreach (var userOrdenado in listaOrdenada)
            {
                AppUsers.Add(userOrdenado);
            }

            ThisUser = new User();

            ThisUser = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

            for (int i=0; i < AppUsers.Count; i++)
            {
                AppUsers[i].RankingPosition = (i+1).ToString() + ". ";

            }

            InsertPageTitleAndPoints();

            foreach (var user in AppUsers)
            {
                if (ThisUser.UsuarioId == user.UsuarioId)
                {
                    ThisUser.RankingPosition = user.RankingPosition;
                    ThisUser.Name = user.Name;
                    ThisUser.TotalPoints = user.TotalPoints;
                }
            }
        }

        private List<User> ListaOrdenada()
        {
            var listainvertida = AppUsers.OrderBy(user => user.TotalPoints).ToList();
            var listaCorreta = new List<User>();

            for (int i = 0; i < listainvertida.Count; i++)
            {
                listaCorreta.Add(listainvertida[listainvertida.Count - i - 1]);
            }
            return listaCorreta;
        }
    }
}
