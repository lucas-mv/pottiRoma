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

        private void FloatingSearchBar_SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBarClientes = sender as SearchBar;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
