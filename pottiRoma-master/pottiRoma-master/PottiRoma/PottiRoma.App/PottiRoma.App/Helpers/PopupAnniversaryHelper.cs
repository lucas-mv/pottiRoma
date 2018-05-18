using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Views.Core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.Helpers
{
    public class PopupAnniversaryHelper
    {
        public static async Task Mostrar(IUserAppService userAppService)
        {
            await CacheAccess.InsertExpire<int>(CacheKeys.DAY_MONTH, DateTime.Now.Day, new TimeSpan(24, 0, 0));
            await PopupNavigation.PushAsync(new PopupAnniversary(userAppService));
        }

        public static async Task EsconderAsync()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
