using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PottiRoma.App.Droid.Renderers;
using PottiRoma.App.CustomRenderers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryAndroid))]
namespace PottiRoma.App.Droid.Renderers
{
    class CustomEntryAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetStroke(5,Android.Graphics.Color.Rgb(200, 200, 200));
        }
    }
}