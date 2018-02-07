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
using System.Linq;
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

        public LandingPageViewModel(
            ISeasonAppService seasonAppService,
            INavigationService navigationService,
            IGamificationPointsAppService gamificationPointsAppService,
            IUserAppService userAppService)
        {
            _seasonAppService = seasonAppService;
            _navigationService = navigationService;
            _gamificationPointsAppService = gamificationPointsAppService;
            _userAppService = userAppService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                var currentSeasonReponse = await _seasonAppService.CurrentSeason();
                //var currentPoints = await _gamificationPointsAppService.GetCurrentGamificationPoints();
                //await CacheAccess.InsertSecure<Points>(CacheKeys.POINTS, currentPoints.Entity);
                await CacheAccess.InsertSecure<Season>(CacheKeys.SEASON_KEY, currentSeasonReponse.Entity);
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var token = await CacheAccess.GetSecure<Guid>(CacheKeys.ACCESS_TOKEN);
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

        public override async void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }
    }
}
