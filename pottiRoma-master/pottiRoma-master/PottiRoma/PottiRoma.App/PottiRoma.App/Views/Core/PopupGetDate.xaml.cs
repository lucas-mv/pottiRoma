using PottiRoma.App.Helpers;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.ViewModels;
using Prism.Commands;
using Rg.Plugins.Popup.Pages;
using Syncfusion.SfPicker.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PottiRoma.App.Views.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupGetDate : PopupPage
    {
        public PopupGetDate()
        {
            InitializeComponent();
            BindingContext = new PopupGetDateViewModel();

            DayPicker.SelectionChanged += DayPicker_SelectionChanged;
            MonthPicker.SelectionChanged += MonthPicker_SelectionChanged;
        }

        private void MonthPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDays(e);
        }

        public void UpdateDays(SelectionChangedEventArgs e)
        {
            var viewModel = BindingContext as PopupGetDateViewModel;

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (e.OldValue != null && e.NewValue != null)
                    {
                        ObservableCollection<object> days = new ObservableCollection<object>();
                        int month = GetDatePopupHelper.ConvertBack((string)e.NewValue);

                        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                            viewModel.Days = viewModel.FillDays(31);
                        else if(month == 2)
                            viewModel.Days = viewModel.FillDays(29);
                        else
                            viewModel.Days = viewModel.FillDays(30);
                    }
                }
                catch { }
            });
        }

        private void DayPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}