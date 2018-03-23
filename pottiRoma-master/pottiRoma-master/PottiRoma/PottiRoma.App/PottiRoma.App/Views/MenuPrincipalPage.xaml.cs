using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class MenuPrincipalPage : MasterDetailPage
    {
        public const string SelectedBackgroundColor = "#435861";
        public const double ShadedMenuItem = 0.4d;
        public const double SelectedMenuItem = 1.0d;
        public MenuPrincipalPage()
        {
            InitializeComponent();
            SetInitialScreenState();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private void SetInitialScreenState()
        {
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = SelectedMenuItem;
        }

        private void ContentConvidarFlor_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentConvidarFlor.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentRanking_Clicked(object sender, System.EventArgs e)
        {
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = SelectedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentGameRules_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentGameRules.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentSales_Clicked(object sender, System.EventArgs e)
        {
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSales.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentSettings_Clicked(object sender, System.EventArgs e)
        {
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSettings.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentAlterarDados_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentAlterarDadosPessoais.Opacity = SelectedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentEfetuarLogout_Clicked(object sender, System.EventArgs e)
        {
            ContentEfetuarLogout.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentEfetuarLogout.Opacity = SelectedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentSalesHistory_Clicked(object sender, System.EventArgs e)
        {
            ContentSalesHistory.BackgroundColor = Color.FromHex(SelectedBackgroundColor); ;
            ContentSalesHistory.Opacity = SelectedMenuItem;
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentTrophyRules.BackgroundColor = Color.Transparent;
            ContentTrophyRules.Opacity = ShadedMenuItem;
        }

        private void ContentMyTrophies_Clicked(object sender, System.EventArgs e)
        {
            ContentTrophyRules.BackgroundColor = Color.FromHex(SelectedBackgroundColor); ;
            ContentTrophyRules.Opacity = SelectedMenuItem;
            ContentEfetuarLogout.BackgroundColor = Color.Transparent;
            ContentEfetuarLogout.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentGameRules.BackgroundColor = Color.Transparent;
            ContentGameRules.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentSalesHistory.BackgroundColor = Color.Transparent;
            ContentSalesHistory.Opacity = ShadedMenuItem;
        }
    }
}