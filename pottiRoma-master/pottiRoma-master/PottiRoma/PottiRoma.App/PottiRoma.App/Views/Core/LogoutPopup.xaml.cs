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

namespace PottiRoma.App.Views.Core
{
    public partial class LogoutPopup : PopupPage
    {
        private readonly IUserDialogs _userDialogs;
        private readonly INavigationService _navigationService;

        public LogoutPopup(IUserDialogs userDialogs, INavigationService navigationService)
        {
            InitializeComponent();
            _userDialogs = userDialogs;
            _navigationService = navigationService;
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
            await Task.Delay(500);
            await NavigationHelper.ShowLoading();
            var duration = new TimeSpan(0, 0, 2);
            _userDialogs.Toast("Realizando logout...", duration);

            await Task.Delay(1000);
            await _navigationService.NavigateAsync(NavigationSettings.AbsoluteLogin);
            await NavigationHelper.PopLoading();
        }
    }
}