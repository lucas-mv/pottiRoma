using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class MenuPrincipalPage : MasterDetailPage
    {
        public const string SelectedBackgroundColor = "#435861";
        public MenuPrincipalPage()
        {
            InitializeComponent();
            SetInitialScreenState();
        }

        private void SetInitialScreenState()
        {
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = 1;
        }

        private void ContentConvidarFlor_Clicked(object sender, System.EventArgs e)
        {
            ContentConvidarFlor.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentConvidarFlor.Opacity = 1;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = 0.8;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = 0.8;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = 0.8;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = 0.8;
        }

        private void ContentRanking_Clicked(object sender, System.EventArgs e)
        {
            ContentRanking.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentRanking.Opacity = 1;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = 0.8;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = 0.8;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = 0.8;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = 0.8;
        }

        private void ContentPerfil_Clicked(object sender, System.EventArgs e)
        {
            ContentPerfil.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentPerfil.Opacity = 1;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = 0.8;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = 0.8;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = 0.8;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = 0.8;
        }

        private void ContentSales_Clicked(object sender, System.EventArgs e)
        {
            ContentSales.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSales.Opacity = 1;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = 0.8;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = 0.8;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = 0.8;
            ContentSettings.BackgroundColor = Color.Transparent;
            ContentSettings.Opacity = 0.8;
        }

        private void ContentSettings_Clicked(object sender, System.EventArgs e)
        {
            ContentSettings.BackgroundColor = Color.FromHex(SelectedBackgroundColor);
            ContentSettings.Opacity = 1;
            ContentRanking.BackgroundColor = Color.Transparent;
            ContentRanking.Opacity = 0.8;
            ContentPerfil.BackgroundColor = Color.Transparent;
            ContentPerfil.Opacity = 0.8;
            ContentConvidarFlor.BackgroundColor = Color.Transparent;
            ContentConvidarFlor.Opacity = 0.8;
            ContentSales.BackgroundColor = Color.Transparent;
            ContentSales.Opacity = 0.8;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}