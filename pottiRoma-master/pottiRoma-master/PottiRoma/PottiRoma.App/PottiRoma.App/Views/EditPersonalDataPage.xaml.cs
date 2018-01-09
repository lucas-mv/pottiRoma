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
        }

        private void EditPersonalDataPageContent_SizeChanged(object sender, System.EventArgs e)
        {
            SetInitialScreenHeight();
        }

        private void SetInitialScreenHeight()
        {
            if (ViewModel != null)
                ViewModel.ScreenHeightRequest = (EditPersonalDataPageContent.Width < EditPersonalDataPageContent.Height) ? EditPersonalDataPageContent.Height : 650;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetInitialScreenHeight();
        }
    }
}
