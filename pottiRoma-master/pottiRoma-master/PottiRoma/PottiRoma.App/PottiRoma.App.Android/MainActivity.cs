using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using formsApp = PottiRoma;
using Xfx;
using Prism;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace PottiRoma.App.Droid
{
    [Activity(Label = "PottiRoma", 
        Icon = "@drawable/logo", 
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Plugins_Init();

            Instance = this;
            XfxControls.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);

            UserDialogs.Init(Instance);

            SetStatusBarColor();

            LoadApplication(new App(new AndroidInitializer()));

        }

        private void Plugins_Init()
        {
            // Dialogs e Loading
            UserDialogs.Init(this);
        }

        private void SetStatusBarColor()
        {
            Window window = this.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            window.SetStatusBarColor(Android.Graphics.Color.Rgb(232, 161, 117));
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {
                // Register any platform specific implementations
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}

