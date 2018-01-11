using Xamarin.Forms;

namespace PottiRoma.App.Views
{
    public partial class InviteFlowerPage : ContentPage
    {
        public InviteFlowerPage()
        {
            InitializeComponent();
        }

        private void EditorMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            var thisEditor = sender as Editor;
            EditorPlaceholder.IsVisible = (thisEditor.Text.Length > 0) ? false : true;
        }
    }
}
