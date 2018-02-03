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
    }
}
