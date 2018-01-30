using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PottiRoma.App.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
          MainLauncher = true,
          Label = "PottiRoma",
          NoHistory = true,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnStart()
        {
            base.OnStart();
            StartActivity(typeof(MainActivity));
        }
    }
}