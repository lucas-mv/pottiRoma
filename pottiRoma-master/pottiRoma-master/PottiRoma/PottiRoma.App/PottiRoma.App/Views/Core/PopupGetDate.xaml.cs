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
        public int Month { get; set; }
        public int Day { get; set; }
        private Action<string> CallbackDate;
        public PopupGetDate(Action<string> callbackDate)
        {
            InitializeComponent();
            BindingContext = new PopupGetDateViewModel();
            CallbackDate = callbackDate;

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
                        Month = GetDatePopupHelper.ConvertBack((string)e.NewValue);

                        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                            viewModel.Days = viewModel.FillDays(31);
                        else if (Month == 2)
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
            if (e.OldValue != null && e.NewValue != null)
            {
                Day = int.Parse(e.NewValue.ToString());
            }
        }

        private void ClickOk_Tapped(object sender, EventArgs e)
        {
            CallbackDate?.Invoke(Day.ToString() + "/" + Month.ToString());
        }
    }
}