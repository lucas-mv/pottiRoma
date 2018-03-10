using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class CurrentChallengesPage : ContentPage
    {
        public CurrentChallengesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Voltar");
        }
    }
}
