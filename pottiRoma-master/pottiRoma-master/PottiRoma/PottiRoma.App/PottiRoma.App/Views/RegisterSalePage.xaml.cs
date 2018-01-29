using PottiRoma.App.CustomRenderers;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.ViewModels;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class RegisterSalePage : ContentPage
    {
        public RegisterSalePageViewModel ViewModel
        {
            get
            {
                return (RegisterSalePageViewModel)this.BindingContext;
            }
        }
        public RegisterSalePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Entry_Price_Focused(object sender, FocusEventArgs e)
        {
            var thisEntry = sender as CustomEntry;

            thisEntry.Text = "";
        }

        private void Entry_Price_Unfocused(object sender, FocusEventArgs e)
        {
            var thisEntry = sender as CustomEntry;

            if (!string.IsNullOrEmpty(thisEntry.Text) && !thisEntry.Text.Contains("R$"))
                thisEntry.Text = Formatter.FormatMoney(decimal.Parse(thisEntry.Text));
        }

        private void Entry_Price_Completed(object sender, System.EventArgs e)
        {
            var thisEntry = sender as CustomEntry;

            if (!string.IsNullOrEmpty(thisEntry.Text) && !thisEntry.Text.Contains("R$"))
                thisEntry.Text = Formatter.FormatMoney(decimal.Parse(thisEntry.Text));
        }
    }
}
