using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePageViewModel ViewModel
        {
            get
            {
                return (ProfilePageViewModel)this.BindingContext;
            }
        }
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void SetInitialScreenHeight()
        {
            if (ViewModel != null)
                ViewModel.ScreenHeightRequest = (ProfilePageContent.Width < ProfilePageContent.Height) ? ProfilePageContent.Height : 616;
        }

        private void ProfilePageContent_SizeChanged(object sender, System.EventArgs e)
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
