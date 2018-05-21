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
using System.Linq;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
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
                        users.ListRankingPoints = Formatter.FormatMoney(users.AverageTicketPoints);
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
                        users.ListRankingPoints = Formatter.ConvertToString(users.RegisterClientsPoints);
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
                        users.ListRankingPoints = Formatter.FormatAveragePiecesForSale(users.AverageItensPerSalePoints);

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
                        users.ListRankingPoints = Formatter.ConvertToString(users.InviteAllyFlowersPoints);
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
                        users.ListRankingPoints = Formatter.ConvertToString(users.SalesNumberPoints);
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
                        users.ListRankingPoints = Formatter.ConvertToString(users.RegisterClientsPoints + users.InviteAllyFlowersPoints + users.SalesNumberPoints);
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
            var AppUsersOrdered = new List<User>();
            try
            {
                var users = (await _userAppService.GetAppUsers()).Users;
                var allAppUsers = await _userAppService.GetAllAppUsers();
                
                switch (ListType)
                {
                    case CarouselBannerType.AveragePiecesForSale:
                        users = users.Count < 6 ? users.OrderByDescending(u => u.AverageItensPerSalePoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.AverageItensPerSalePoints).ToList().GetRange(0, 5);

                        foreach (var user in users)
                        {
                            user.ListRankingPoints = Formatter.FormatAveragePiecesForSale(user.AverageItensPerSalePoints);
                        }
                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.AverageItensPerSalePoints).ToList();
                        break;

                    case CarouselBannerType.AverageTicket:

                        users = users.Count < 6 ? users.OrderByDescending(u => u.AverageTicketPoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.AverageTicketPoints).ToList().GetRange(0, 5);
 
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = Formatter.FormatMoney(user.AverageTicketPoints);
                        }
                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.AverageTicketPoints).ToList();
                        break;

                    case CarouselBannerType.RegisterAlliedFlowers:

                        users = users.Count < 6 ? users.OrderByDescending(u => u.InviteAllyFlowersPoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.InviteAllyFlowersPoints).ToList().GetRange(0, 5);

                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.InviteAllyFlowersPoints.ToString();
                        }
                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.InviteAllyFlowersPoints).ToList();
                        break;

                    case CarouselBannerType.RegisterClients:

                        users = users.Count < 6 ? users.OrderByDescending(u => u.RegisterClientsPoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.RegisterClientsPoints).ToList().GetRange(0, 5);

                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.RegisterClientsPoints.ToString();
                        }
                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.RegisterClientsPoints).ToList();
                        break;

                    case CarouselBannerType.RegisteredSales:

                        users = users.Count < 6 ? users.OrderByDescending(u => u.SalesNumberPoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.SalesNumberPoints).ToList().GetRange(0, 5);

                        foreach (var user in users)
                        {
                            user.ListRankingPoints = user.SalesNumberPoints.ToString();
                        }
                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.SalesNumberPoints).ToList();
                        break;

                    case CarouselBannerType.Total:
                        foreach (var user in users)
                        {
                            user.ListRankingPoints = (  user.RegisterClientsPoints +
                                                        user.InviteAllyFlowersPoints +
                                                        user.SalesNumberPoints).ToString();
                            user.TotalPoints = (    user.RegisterClientsPoints +
                                                    user.InviteAllyFlowersPoints +
                                                    user.SalesNumberPoints);
                        }

                        users = users.Count < 6 ? users.OrderByDescending(u => u.TotalPoints).ToList().GetRange(0, users.Count) : users.OrderByDescending(u => u.TotalPoints).ToList().GetRange(0, 5);

                        AppUsersOrdered = allAppUsers.Users.OrderByDescending(user => user.TotalPoints).ToList();
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

            GetThisUserRankingPosition(AppUsersOrdered, ListType);

            AppUsers = FillUserRankingPosition(AppUsers);

            InsertPageTitleAndPoints();

        }

        private void GetThisUserRankingPosition(List<User> appUsersOrdered, CarouselBannerType type)
        {
            int count = 0;

            foreach (var user in appUsersOrdered)
            {
                count++;
                if (user.UsuarioId == ThisUser.UsuarioId)
                {
                    ThisUser.RankingPosition = Formatter.FormatUserRankingPosition(count);
                    switch (type)
                    {
                        case CarouselBannerType.AveragePiecesForSale:
                            ThisUser.ListRankingPoints = Formatter.FormatAveragePiecesForSale(user.AverageItensPerSalePoints);
                            break;
                        case CarouselBannerType.AverageTicket:
                            ThisUser.ListRankingPoints = Formatter.FormatMoney(user.AverageTicketPoints);
                            break;
                        case CarouselBannerType.RegisterAlliedFlowers:
                            ThisUser.ListRankingPoints = Formatter.ConvertToString(user.InviteAllyFlowersPoints);
                            break;
                        case CarouselBannerType.RegisterClients:
                            ThisUser.ListRankingPoints = Formatter.ConvertToString(user.RegisterClientsPoints);
                            break;
                        case CarouselBannerType.RegisteredSales:
                            ThisUser.ListRankingPoints = Formatter.ConvertToString(user.SalesNumberPoints);
                            break;
                        case CarouselBannerType.Total:
                            ThisUser.ListRankingPoints = Formatter.ConvertToString(user.InviteAllyFlowersPoints + user.RegisterClientsPoints + user.SalesNumberPoints);
                            break;
                    }
                }
            }
        }

        private ObservableCollection<User> FillUserRankingPosition(ObservableCollection<User> appUsers)
        {
            for (int i = 0; i < AppUsers.Count; i++)
            {
                appUsers[i].RankingPosition = Formatter.FormatUserRankingPosition(i + 1);
            }
            return appUsers;
        }

    }
}
