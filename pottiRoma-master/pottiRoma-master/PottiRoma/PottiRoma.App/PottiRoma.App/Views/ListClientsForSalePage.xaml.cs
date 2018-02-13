using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.Helpers;
using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class ListClientsForSalePage : ContentPage
    {
        public ListClientsForSalePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SearchBarClientesForSale.Text = "";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchBarClientesForSale.TextChanged += TextoPesquisaChanged;
        }

        private void TextoPesquisaChanged(object sender, TextChangedEventArgs e)
        {
            var ThisSearchBar = (sender as SearchBar);
            if (ClientsListView.DataSource != null)
            {
                ClientsListView.DataSource.Filter = FiltrarClientes;
                ClientsListView.DataSource.RefreshFilter();
            }
        }

        private bool FiltrarClientes(object item)
        {
            if (SearchBarClientesForSale == null || SearchBarClientesForSale.Text == null) return true;

            var cliente = item as Client;

            string textolista;
            string textobarra;
            bool ok = false;

            Translate translate = new Translate();
            textobarra = translate.TranslateString(SearchBarClientesForSale.Text.ToLower());

            if (cliente != null)
            {
                if (!string.IsNullOrEmpty(cliente.Name))
                {
                    textolista = translate.TranslateString(cliente.Name.ToLower());
                    if (textolista.Contains(textobarra))
                        ok = true;
                }
            }
            return ok;
        }
    }
}
