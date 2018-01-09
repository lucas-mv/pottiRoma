using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class MyClientsPage : ContentPage
    {
        public MyClientsPageViewModel ViewModel
        {
            get
            {
                return (MyClientsPageViewModel)this.BindingContext;
            }
        }

        public MyClientsPage()
        {
            InitializeComponent();
        }

        private void SetInitialScreenHeight()
        {
            if (ViewModel != null)
                ViewModel.ScreenHeightRequest = (MyClientsPageContent.Width < MyClientsPageContent.Height) ? MyClientsPageContent.Height : 650;
        }

        private void MyClientsPageContent_SizeChanged(object sender, System.EventArgs e)
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
