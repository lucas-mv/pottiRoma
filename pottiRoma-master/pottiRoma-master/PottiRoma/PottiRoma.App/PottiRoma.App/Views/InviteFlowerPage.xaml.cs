using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class InviteFlowerPage : ContentPage
    {
        public InviteFlowerPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Voltar");
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
