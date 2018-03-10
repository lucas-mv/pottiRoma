using PottiRoma.App.Models.Models;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.ViewModels;
using PottiRoma.App.ViewModels.Core;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PottiRoma.App.Views.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAnniversary : PopupPage
    {
        public PopupAnniversary(IUserAppService userAppService)
        {
            InitializeComponent();
            BindingContext = new PopupAnniversaryViewModel(userAppService);
        }
    }
}