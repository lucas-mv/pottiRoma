using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class RankingPage : ContentPage
    {
        public RankingPageViewModel ViewModel
        {
            get
            {
                return (RankingPageViewModel)this.BindingContext;
            }
        }
        public RankingPage()
        {
            InitializeComponent();
            ScrollView.ScrollToAsync(1436, 1435, false);
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
