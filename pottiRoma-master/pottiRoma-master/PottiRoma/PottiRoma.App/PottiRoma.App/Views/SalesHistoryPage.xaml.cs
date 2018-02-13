using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.Helpers;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class SalesHistoryPage : ContentPage
    {
        public SalesHistoryPage()
        {
            InitializeComponent();
        }

        private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var thisLabel = sender as Label;

            if (!string.IsNullOrEmpty(thisLabel.Text) && !thisLabel.Text.Contains("R$"))
                thisLabel.Text = Formatter.FormatMoney(decimal.Parse(thisLabel.Text));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchBarHistorySales.TextChanged += TextoPesquisaChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SearchBarHistorySales.Text = "";
        }

        private void TextoPesquisaChanged(object sender, TextChangedEventArgs e)
        {
            var ThisSearchBar = (sender as SearchBar);
            if (SalesListView.DataSource != null)
            {
                SalesListView.DataSource.Filter = FiltrarClientes;
                SalesListView.DataSource.RefreshFilter();
            }
        }

        private bool FiltrarClientes(object item)
        {
            if (SearchBarHistorySales == null || SearchBarHistorySales.Text == null) return true;

            var sale = item as Sale;

            string textolista;
            string textobarra;
            bool ok = false;

            Translate translate = new Translate();
            textobarra = translate.TranslateString(SearchBarHistorySales.Text.ToLower());

            if (sale != null)
            {
                if (!string.IsNullOrEmpty(sale.ClientName))
                {
                    textolista = translate.TranslateString(sale.ClientName.ToLower());
                    if (textolista.Contains(textobarra))
                        ok = true;
                }
            }
            return ok;
        }
    }
}
