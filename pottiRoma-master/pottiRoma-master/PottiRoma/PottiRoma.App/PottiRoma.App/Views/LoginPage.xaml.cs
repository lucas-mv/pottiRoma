using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPageViewModel ViewModel
        {
            get
            {
                return (LoginPageViewModel)this.BindingContext;
            }
        }

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void SetInitialScreenHeight()
        {
            if (ViewModel != null)
                ViewModel.ScreenHeightRequest = (LoginPageContent.Width < LoginPageContent.Height) ? LoginPageContent.Height : 650;
        }

        private void LoginPageContent_SizeChanged(object sender, System.EventArgs e)
        {
            SetInitialScreenHeight();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetInitialScreenHeight();
        }
    }
}
