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

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await ScrollImages.ScrollToAsync(605, 605, true);
            });
            base.OnAppearing();
        }
    }
}
