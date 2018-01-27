using PottiRoma.App.Dtos;
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


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void SfCarousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            ViewModel.SelectedIndex = e.SelectedIndex;
        }
    }
}
