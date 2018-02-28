using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PottiRoma.App.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Repositories.Internal;
using static PottiRoma.App.Utils.Constants;
using PottiRoma.App.Models.Models;
using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using PottiRoma.App.Insights;

namespace PottiRoma.App.Views.Core
{
    public partial class LogoutPopup : PopupPage
    {
        private readonly IUserDialogs _userDialogs;
        private readonly INavigationService _navigationService;
        private readonly IUserAppService _userAppService;

        public LogoutPopup(
            IUserDialogs userDialogs, 
            INavigationService navigationService,
            IUserAppService userAppService)
        {
            InitializeComponent();
            _userDialogs = userDialogs;
            _navigationService = navigationService;
            _userAppService = userAppService;

            BindingContext = new
            {
                ConfirmaLogoutCommand = new DelegateCommand(Confirm),
                CancelaLogoutCommand = new DelegateCommand(Cancel)
            };
        }

        private async void Cancel()
        {
            await LogoutPopupHelper.EsconderAsync();
        }

        private async void Confirm()
        {
            try
            {
                await NavigationHelper.ShowLoading();
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                await _userAppService.Logout(user.UsuarioId.ToString());
                await CacheAccess.DeleteAll();
                await _navigationService.NavigateAsync(NavigationSettings.AbsoluteLogin);
                try
                {
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                {
                    { InsightsPagesNames.LoginPage, InsightsActionNames.Logout }
                });
                }
                catch { }
            }
            catch(Exception ex)
            {
                _userDialogs.Toast(ex.Message);
                await NavigationHelper.PopLoading();
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
        }
    }
}