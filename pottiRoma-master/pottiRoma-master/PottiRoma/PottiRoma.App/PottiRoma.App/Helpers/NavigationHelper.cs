using PottiRoma.App.Views.Core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public static class NavigationHelper
    {
        private static PopupLoading _popupLoading;

        public static async Task ShowLoading()
        {
            _popupLoading = new PopupLoading();
            await PopupNavigation.PushAsync(_popupLoading);
        }

        public static async Task PopLoading(bool popAll = true)
        {
            if (_popupLoading == null) return;
            _popupLoading = null;
            if (popAll)
                await PopupNavigation.PopAllAsync();
            else
                await PopupNavigation.PopAsync();
        }
    }
}
