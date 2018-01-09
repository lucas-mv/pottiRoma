using Acr.UserDialogs;
using PottiRoma.App.Views.Core;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public class LogoutPopupHelper
    {
        public static async Task Mostrar(IUserDialogs userDialogs, INavigationService navigationService)
        {
            await PopupNavigation.PushAsync(new LogoutPopup(userDialogs, navigationService));
        }

        public static async Task EsconderAsync()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
