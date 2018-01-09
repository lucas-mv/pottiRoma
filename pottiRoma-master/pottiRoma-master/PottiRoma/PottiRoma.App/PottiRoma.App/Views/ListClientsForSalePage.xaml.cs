using PottiRoma.App.Models;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchBarClientes.TextChanged += TextoPesquisaChanged;
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
            if (SearchBarClientes == null || SearchBarClientes.Text == null) return true;

            var cliente = item as Cliente;

            string textolista;
            string textobarra;
            bool ok = false;

            Translate translate = new Translate();
            textobarra = translate.TranslateString(SearchBarClientes.Text.ToLower());

            if (cliente != null)
            {
                if (cliente.Nome != null)
                {
                    textolista = translate.TranslateString(cliente.Nome.ToLower());
                    if (textolista.Contains(textobarra))
                        ok = true;
                }
            }
            return ok;
        }

    }
}
