using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using PottiRoma.App.CustomRenderers;
using PottiRoma.App.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorIOS))]
namespace PottiRoma.App.iOS.Renderers
{
    public class CustomEditorIOS : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.BorderColor = Color.Transparent.ToCGColor();
            }
        }
    }
}