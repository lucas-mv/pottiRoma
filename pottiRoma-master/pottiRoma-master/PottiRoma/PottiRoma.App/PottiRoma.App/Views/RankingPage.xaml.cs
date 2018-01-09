using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class RankingPage : ContentPage
    {
        public RankingPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
