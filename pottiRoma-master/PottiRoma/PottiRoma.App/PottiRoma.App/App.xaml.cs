using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PottiRoma.App
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            StartNavigation();
        }

        private void StartNavigation()
        {
            if (0 == 0/*AUTENTICACAO DO AD*/)
                NavigationService.NavigateAsync(NavigationSettings.DashBoard);
            else
                NavigationService.NavigateAsync(NavigationSettings.Login);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<DashBoardPage>();
            Container.RegisterTypeForNavigation<RegisterClientsPage>();
            Container.RegisterTypeForNavigation<EditPersonalDataPage>();
        }
    }
}
