using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class EditPersonalDataPage : ContentPage
    {
        public EditPersonalDataPageViewModel ViewModel
        {
            get
            {
                return (EditPersonalDataPageViewModel)this.BindingContext;
            }
        }
        public EditPersonalDataPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
