using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class MenuPrincipalPage : MasterDetailPage
    {
        public const string SelectedBackgroundColor = "#435861";
        public const double ShadedMenuItem = 0.7d;
        public const double SelectedMenuItem = 1.0d;
        public MenuPrincipalPage()
        {
            InitializeComponent();
            SetInitialScreenState();
        }

        private void SetInitialScreenState()
        {
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = SelectedMenuItem;
        }

        private void ContentConvidarFlor_Clicked(object sender, System.EventArgs e)
        {
            ContentConvidarFlor.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentConvidarFlor.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
        }

        private void ContentRanking_Clicked(object sender, System.EventArgs e)
        {
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = SelectedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
        }

        private void ContentPerfil_Clicked(object sender, System.EventArgs e)
        {
            ContentPerfil.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentPerfil.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
        }

        private void ContentSales_Clicked(object sender, System.EventArgs e)
        {
            ContentSales.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSales.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
        }

        private void ContentSettings_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSettings.Opacity = SelectedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.Transparent;
            ContentAlterarDadosPessoais.Opacity = ShadedMenuItem;
        }

        private void ContentAlterarDados_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = ShadedMenuItem;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = ShadedMenuItem;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = ShadedMenuItem;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = ShadedMenuItem;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = ShadedMenuItem;
            ContentAlterarDadosPessoais.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentAlterarDadosPessoais.Opacity = SelectedMenuItem;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}