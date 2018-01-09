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
        }

        private void SetInitialScreenHeight()
        {
            if (ViewModel != null)
                ViewModel.ScreenHeightRequest = (RankingPageContent.Width < RankingPageContent.Height) ? RankingPageContent.Height : 650;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetInitialScreenHeight();
        }

        private void RankingPageContent_SizeChanged(object sender, System.EventArgs e)
        {
            SetInitialScreenHeight();
        }
    }
}
