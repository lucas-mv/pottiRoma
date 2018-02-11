using PottiRoma.App.Models.Models;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Views.Core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public class PopupAnniversaryHelper
    {
        public static async Task Mostrar(IUserAppService userAppService)
        {
            await PopupNavigation.PushAsync(new PopupAnniversary(userAppService));
        }

        public static async Task EsconderAsync()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
