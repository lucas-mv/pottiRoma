using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class RegisterClientsPage : ContentPage
    {
        public RegisterClientsPageViewModel ViewModel
        {
            get
            {
                return (RegisterClientsPageViewModel)this.BindingContext;
            }
        }

        public RegisterClientsPage()
        {
            InitializeComponent();
        }
    }
}
