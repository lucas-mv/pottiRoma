using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PottiRoma.App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusBarIOS : ContentView
    {
        public StatusBarIOS()
        {
            InitializeComponent();
        }
    }
}