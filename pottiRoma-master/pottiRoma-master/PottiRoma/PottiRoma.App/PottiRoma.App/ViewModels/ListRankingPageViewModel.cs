using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Responses.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Enums;
using PottiRoma.App.Utils.Helpers;
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

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
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
                    ImageSource = "banner_porquinho_ranking.png";
                    foreach (var users in AppUsers)
                    users.TotalPoints = users.AverageTicketPoints;
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingAverageTicket }
                        });
                    }
                    catch { }
                    break;
                case CarouselBannerType.RegisterClients:
                    Title = "Cadastro de Colecionadoras";
                    ImageSource = "banner_colecionadoras_ranking.png";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.RegisterClientsPoints;
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingRegisterClients }
                        });
                    }
                    catch { }
                    break;
                case CarouselBannerType.AveragePiecesForSale:
                    Title = "Peças por Atendimento";
                    ImageSource = "banner_varal.png";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.AverageItensPerSalePoints;
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingPiecesForSale }
                        });
                    }
                    catch { }
                    break;
                case CarouselBannerType.RegisterAlliedFlowers:
                    Title = "Cadastro de Flores Aliadas";
                    ImageSource = "banner_flor.png";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.InviteAllyFlowersPoints;
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingInviteFlowers }
                        });
                    }
                    catch { }
                    break;
                case CarouselBannerType.RegisteredSales:
                    Title = "Atendimento";
                    ImageSource = "banner_atendimento_ranking.png";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.SalesNumberPoints;
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRankingSales }
                        });
                    }
                    catch { }
                    break;
                case CarouselBannerType.Total:
                    Title = "Geral";
                    ImageSource = "banner_manequim_ranking.png";
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
                var users = (await _userAppService.GetAppUsers()).Users;
                switch (ListType)
                {
                    case CarouselBannerType.AveragePiecesForSale:
                        users = users.OrderByDescending(u => u.AverageItensPerSalePoints).ToList().GetRange(0, 5);
                        foreach(var user in users)
                        {
                            user.ListRankingPoints = user.AverageItensPerSalePoints.ToString() + " und";
                        }
                        break;

                    case CarouselBannerType.AverageTicket:
                        users = users.OrderByDescending(u => u.AverageTicketPoints).ToList().GetRange(0, 5);
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = Formatter.FormatMoney(user.AverageTicketPoints);
                        }
                        break;

                    case CarouselBannerType.RegisterAlliedFlowers:
                        users = users.OrderByDescending(u => u.InviteAllyFlowersPoints).ToList().GetRange(0, 5);
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.InviteAllyFlowersPoints.ToString();
                        }
                        break;

                    case CarouselBannerType.RegisterClients:
                        users = users.OrderByDescending(u => u.RegisterClientsPoints).ToList().GetRange(0, 5);
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.RegisterClientsPoints.ToString();
                        }
                        break;

                    case CarouselBannerType.RegisteredSales:
                        users = users.OrderByDescending(u => u.SalesNumberPoints).ToList().GetRange(0, 5);
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.SalesNumberPoints.ToString();
                        }
                        break;

                    case CarouselBannerType.Total:
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = (user.SalesNumberPoints + 
                                                        user.RegisterClientsPoints +
                                                        user.InviteAllyFlowersPoints + 
                                                        user.AverageItensPerSalePoints + 
                                                        user.AverageTicketPoints).ToString();
                            user.TotalPoints = (user.SalesNumberPoints +
                                                        user.RegisterClientsPoints +
                                                        user.InviteAllyFlowersPoints +
                                                        user.AverageItensPerSalePoints +
                                                        user.AverageTicketPoints);
                        }
                        users = users.OrderByDescending(u => u.TotalPoints).ToList().GetRange(0, 5);
                        break;
                }
                foreach (var user in users)
                {
                    AppUsers.Add(user);
                }

            }
            catch
            {
                _userDialogs.Toast("Não foi possível obter os usuários");
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }


            ThisUser = new User();

            ThisUser = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

            for (int i = 0; i < AppUsers.Count; i++)
            {
                AppUsers[i].RankingPosition = (i + 1).ToString() + ". ";
            }

            InsertPageTitleAndPoints();

            foreach (var user in AppUsers)
            {
                if (ThisUser.UsuarioId == user.UsuarioId)
                {
                    ThisUser.RankingPosition = user.RankingPosition;
                    ThisUser.Name = user.Name;
                    ThisUser.TotalPoints = user.TotalPoints;
                    ThisUser.ListRankingPoints = user.ListRankingPoints;
                }
            }
        }
    }
}
