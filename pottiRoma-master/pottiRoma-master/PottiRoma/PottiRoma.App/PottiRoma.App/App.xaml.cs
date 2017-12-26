using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.Views;
using PottiRoma.App.Views.Core;
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
            NavigationService.NavigateAsync(NavigationSettings.Login);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<RegisterClientsPage>();
            Container.RegisterTypeForNavigation<EditPersonalDataPage>();
            Container.RegisterTypeForNavigation<MenuPrincipalPage>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<RankingPage>();
            Container.RegisterTypeForNavigation<ProfilePage>();
            Container.RegisterTypeForNavigation<MySalesPage>();
            Container.RegisterTypeForNavigation<ProfileTabbedPage>();
            Container.RegisterTypeForNavigation<GamificationRulesPage>();
            Container.RegisterTypeForNavigation<InviteFlowerPage>();
            Container.RegisterTypeForNavigation<NewSalesPage>();
            Container.RegisterTypeForNavigation<ListClientsPage>();
            Container.RegisterTypeForNavigation<ResetPasswordPage>();
            Container.RegisterTypeForNavigation<RegisterSalePage>();
        }
    }
}
