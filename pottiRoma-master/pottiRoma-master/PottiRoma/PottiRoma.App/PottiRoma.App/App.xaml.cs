using Acr.UserDialogs;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Practices.Unity;
using PottiRoma.App.Models.Requests.User;
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
            AppCenter.Start("ios=ce1bfa28-94c8-4ffc-9726-fad5c55172f9;android=8085118a-c304-4b96-b2f2-b1468761f934", typeof(Analytics), typeof(Crashes));
            InitializeComponent();
            StartNavigation();
        }

        private void StartNavigation()
        {
            NavigationService.NavigateAsync(NavigationSettings.Landing);
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
            Container.RegisterTypeForNavigation<ListRankingPage>();
            Container.RegisterTypeForNavigation<LandingPage>();
        }
    }
}
