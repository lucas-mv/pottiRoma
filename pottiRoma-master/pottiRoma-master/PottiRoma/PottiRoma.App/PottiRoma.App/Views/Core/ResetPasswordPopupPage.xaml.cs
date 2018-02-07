using PottiRoma.App.CustomRenderers;
using PottiRoma.App.ViewModels.Core;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PottiRoma.App.Views.Core
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResetPasswordPopupPage : PopupPage
    {
        private Action<string> CallbackDate;
        public ResetPasswordPopupPage (Action<string> callbackGetEmail)
		{
			InitializeComponent ();
            BindingContext = new ResetPasswordPopupPageViewModel();
            CallbackDate = callbackGetEmail;
        }

        private void ClickOk_Tapped(object sender, EventArgs e)
        {
            CallbackDate?.Invoke(EntryEmailForReset.Text);
        }
    }
}