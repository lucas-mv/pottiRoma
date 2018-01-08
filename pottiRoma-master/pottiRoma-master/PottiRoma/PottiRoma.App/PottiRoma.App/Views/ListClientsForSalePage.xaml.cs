using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class ListClientsForSalePage : ContentPage
    {
        public ListClientsForSalePage()
        {
            InitializeComponent();
        }

        private void FloatingSearchBar_SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBarClientes = sender as SearchBar;

            //if (FuncionariosListView.DataSource != null)
            //{
            //    FuncionariosListView.DataSource.Filter = FiltrarFuncionarios;
            //    FuncionariosListView.DataSource.RefreshFilter();
            //}
        }
    }
}
