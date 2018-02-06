using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Microsoft.Practices.Unity;
using Prism;
using Prism.Unity;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfCarousel.XForms.iOS;
using Syncfusion.SfPicker.XForms.iOS;
using UIKit;
using Xfx;

namespace PottiRoma.App.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            XfxControls.Init();

            global::Xamarin.Forms.Forms.Init();

            InitializePlugins();

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UIApplication.SharedApplication.SetStatusBarHidden(false, false);

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        private void InitializePlugins()
        {
            SfListViewRenderer.Init();
            new SfBusyIndicatorRenderer();
            SfPickerRenderer.Init();
            new SfCarouselRenderer();
        }
    }
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}
