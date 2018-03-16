using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils;
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
using Xamarin.Forms;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        private readonly ISeasonAppService _seasonAppService;
        private readonly INavigationService _navigationService;
        private readonly IGamificationPointsAppService _gamificationPointsAppService;
        private readonly IUserAppService _userAppService;
        private readonly IClientsAppService _clientsAppService;
        private readonly IChallengesAppService _challengesAppService;
        private readonly ITrophyAppService _trophyAppService;

        public LandingPageViewModel(
            ISeasonAppService seasonAppService,
            INavigationService navigationService,
            IGamificationPointsAppService gamificationPointsAppService,
            IUserAppService userAppService,
            IClientsAppService clientsAppService,
            IChallengesAppService challengesAppService,
            ITrophyAppService trophyAppService)
        {
            _seasonAppService = seasonAppService;
            _navigationService = navigationService;
            _gamificationPointsAppService = gamificationPointsAppService;
            _userAppService = userAppService;
            _clientsAppService = clientsAppService;
            _challengesAppService = challengesAppService;
            _trophyAppService = trophyAppService;
        }

        private ObservableCollection<Client> localBirthdays;

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var token = await CacheAccess.GetSecure<Guid>(CacheKeys.ACCESS_TOKEN);
                var currentSeasonReponse = await _seasonAppService.CurrentSeason();
                var currentClients = await _clientsAppService.GetClientsByUserId(user.UsuarioId.ToString());
                var myTrophies = await _trophyAppService.GetCurrentTrophies(user.UsuarioId.ToString());
                await CacheAccess.Insert<List<Client>>(CacheKeys.CLIENTS, currentClients.Clients);
                await CacheAccess.InsertSecure<Season>(CacheKeys.SEASON_KEY, currentSeasonReponse.Entity);
                await CacheAccess.Insert<List<Trophy>>(CacheKeys.TROPHIES, myTrophies.Trophies);
                var currentChallenges = await _challengesAppService.GetCurrentChallenges(currentSeasonReponse.Entity.TemporadaId.ToString());
                await CacheAccess.Insert<List<Challenge>>(CacheKeys.CHALLENGES, currentChallenges.Challenges);
           
                localBirthdays = await CheckAnniversary();

                Settings.AccessToken = token.ToString();
                Settings.UserId = user.UsuarioId.ToString();
                await CheckInviteChallengeCompleted( myTrophies.Trophies, user.UsuarioId.ToString(), currentChallenges.Challenges, currentSeasonReponse.Entity);
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }
            catch
            {
                Settings.AccessToken = string.Empty;
                Settings.UserId = string.Empty;
                await _navigationService.NavigateAsync(NavigationSettings.AbsoluteLogin);
            }
            finally
            {
            }
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            parameters.Add(NavigationKeyParameters.FirstAccess, "true");

            if (localBirthdays != null)
            {
                if (localBirthdays.Count > 0)
                    parameters.Add(NavigationKeyParameters.ClientsBirthday, localBirthdays);
            }

            base.OnNavigatedFrom(parameters);
        }

        private async Task CheckInviteChallengeCompleted(List<Trophy> myTrophies, string usuarioId, List<Challenge> currentChallenges, Season CurrentSeason)
        {
            try
            {
                int myInvitePoints = 0;
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

                try
                {
                    myInvitePoints = await CacheAccess.Get<int>(CacheKeys.INVITE_POINTS_FOR_CHALLENGE);
                }
                catch
                {
                    myInvitePoints = await _userAppService.GetUserInvitePointsForChallenge(usuarioId);
                    await CacheAccess.Insert<int>(CacheKeys.INVITE_POINTS_FOR_CHALLENGE, myInvitePoints);
                }

                foreach (var challenge in currentChallenges)
                {
                    bool _hasTrophy = false;
                    bool _hasEnoughtPoints = false;
                    if (challenge.Parameter == 2)
                    {
                        foreach (var trophy in myTrophies)
                        {
                            if (trophy.DesafioId.ToString() == challenge.DesafioId.ToString())
                            {
                                _hasTrophy = true;
                                break;
                            }
                        }
                        _hasEnoughtPoints = (myInvitePoints >= challenge.Goal) ? true : false;
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
                            UsuarioId = new Guid(usuarioId)
                        });
                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints + challenge.Prize,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            SalesNumberPoints = user.SalesNumberPoints,
                            UsuarioId = user.UsuarioId
                        });
                        UserDialogs.Instance.Toast("Você acabou de ganhar um Troféu de Convite de Flores Aliadas! Parabéns!", new TimeSpan(0, 0, 4));
                    }
                }
            }
            catch { }
        }


        private async Task<ObservableCollection<Client>> CheckAnniversary()
        {
            var clients = await CacheAccess.Get<List<Client>>(CacheKeys.CLIENTS);

            var clientsBirthday = new ObservableCollection<Client>();

            foreach (var client in clients)
            {
                if (client.Birthdate.Day == DateTime.Now.Day && client.Birthdate.Month == DateTime.Now.Month)
                    clientsBirthday.Add(client);
            }
            return clientsBirthday;
        }
    }
}
