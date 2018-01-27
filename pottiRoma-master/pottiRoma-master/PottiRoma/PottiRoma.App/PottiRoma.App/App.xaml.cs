using Acr.UserDialogs;
using Microsoft.Practices.Unity;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.Views;
using PottiRoma.App.Views.Core;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PottiRoma.App
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            StartNavigation();
        }

        private void StartNavigation()
        {
            NavigationService.NavigateAsync(NavigationSettings.Login, useModalNavigation: true);
        }

        protected override void RegisterTypes()
        {
            BootStrapperIoC.Init(Container);
            Container.RegisterInstance(UserDialogs.Instance);
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<RegisterClientsPage>();
            Container.RegisterTypeForNavigation<EditPersonalDataPage>();
            Container.RegisterTypeForNavigation<MenuPrincipalPage>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<RankingPage>();
            Container.RegisterTypeForNavigation<GamificationRulesPage>();
            Container.RegisterTypeForNavigation<InviteFlowerPage>();
            Container.RegisterTypeForNavigation<ResetPasswordPage>();
            Container.RegisterTypeForNavigation<RegisterSalePage>();
            Container.RegisterTypeForNavigation<PopupLoading>();
            Container.RegisterTypeForNavigation<ListClientsForSalePage>();
            Container.RegisterTypeForNavigation<MyClientsPage>();
            Container.RegisterTypeForNavigation<PopupGetDate>();
            Container.RegisterTypeForNavigation<TrophyRoomPage>();
            Container.RegisterTypeForNavigation<SalesHistoryPage>();
        }
    }
}
