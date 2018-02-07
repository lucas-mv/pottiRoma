using PottiRoma.App.Views.Core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public class ResetPasswordPopupHelper
    {
        public static async Task Mostrar(Action<string> CallBackGetEmail)
        {
            await PopupNavigation.PushAsync(new ResetPasswordPopupPage(CallBackGetEmail));
        }

        public static async Task EsconderAsync()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
