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

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            ViewModel.LoginIncorreto = false;
        }
    }
}
