using System;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.Helpers;
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
            SearchBarClientes.TextChanged += TextoPesquisaChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SearchBarClientes.Text = "";
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

            var cliente = item as Client;

            string textolista;
            string textobarra;
            bool ok = false;

            Translate translate = new Translate();
            textobarra = translate.TranslateString(SearchBarClientes.Text.ToLower());

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
