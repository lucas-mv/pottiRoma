using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
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

        public LandingPageViewModel(
            ISeasonAppService seasonAppService,
            INavigationService navigationService,
            IGamificationPointsAppService gamificationPointsAppService,
            IUserAppService userAppService,
            IClientsAppService clientsAppService)
        {
            _seasonAppService = seasonAppService;
            _navigationService = navigationService;
            _gamificationPointsAppService = gamificationPointsAppService;
            _userAppService = userAppService;
            _clientsAppService = clientsAppService;
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
                var currentPoints = await _gamificationPointsAppService.GetCurrentGamificationPoints();
                var currentClients = await _clientsAppService.GetClientsByUserId(user.UsuarioId.ToString());
                await CacheAccess.Insert<List<Client>>(CacheKeys.CLIENTS, currentClients.Clients);
                await CacheAccess.InsertSecure<Points>(CacheKeys.POINTS, currentPoints.Entity);
                await CacheAccess.InsertSecure<Season>(CacheKeys.SEASON_KEY, currentSeasonReponse.Entity);
                localBirthdays = await CheckAnniversary();

                Settings.AccessToken = token.ToString();
                Settings.UserId = user.UsuarioId.ToString();

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
