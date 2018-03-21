using Xamarin.Forms;

namespace PottiRoma.App.Views.Core
{
    public partial class MainNavigationPage : NavigationPage
    {
        public MainNavigationPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.FromHex("#ffd195");
            this.BarTextColor = Color.White;
            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
