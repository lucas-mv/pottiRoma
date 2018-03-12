using PottiRoma.App.CustomRenderers;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.ViewModels;
using System.Threading.Tasks;
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

            ContentRegisterSalePage.HeightRequest += 150;
            if (!ViewModel._isEditSale)
            {
                Entry_sold_pieces.Text = "";
                Entry_total_price.Text = "";
                Entry_price.Text = "";
            }
            else
            {
                Entry_total_price.Text = Formatter.FormatMoney((decimal)ViewModel.SaleRegistered.SaleValue);
                Entry_price.Text = Formatter.FormatMoney((decimal)ViewModel.SaleRegistered.SalePaidValue);
            }
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

        private void NumberSoldPieces_focused(object sender, FocusEventArgs e)
        {
            var thisEntry = sender as CustomEntry;
            thisEntry.Text = "";
        }

        private void Editor_observacoes_placeholder_Focused(object sender, FocusEventArgs e)
        {
            ViewModel.DescriptionPlaceHolderVisible = false;
        }

        private void Editor_observacoes_placeholder_Unfocused(object sender, FocusEventArgs e)
        {
            if (ObservacoesEditor.Text == null)
                ObservacoesEditor.Text = "";
            if (ObservacoesEditor != null && ObservacoesEditor.Text != null)
                ViewModel.DescriptionPlaceHolderVisible = (ObservacoesEditor.Text.Length < 1) ? true : false;
        }
    }
}
