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
            NavigationService.NavigateAsync(NavigationSettings.Login,useModalNavigation : true);
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
            Container.RegisterTypeForNavigation<ProfileTabbedPage>();
            Container.RegisterTypeForNavigation<GamificationRulesPage>();
            Container.RegisterTypeForNavigation<InviteFlowerPage>();
            Container.RegisterTypeForNavigation<NewSalesPage>();
            Container.RegisterTypeForNavigation<ListClientsPage>();
            Container.RegisterTypeForNavigation<ResetPasswordPage>();
            Container.RegisterTypeForNavigation<RegisterSalePage>();
            Container.RegisterTypeForNavigation<PopupLoading>();
            Container.RegisterTypeForNavigation<ListClientsForSalePage>();
        }
    }
}
