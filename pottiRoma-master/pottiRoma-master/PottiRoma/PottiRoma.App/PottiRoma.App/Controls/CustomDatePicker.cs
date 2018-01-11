using Syncfusion.SfPicker.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PottiRoma.App.Controls
{
    public class CustomDatePicker : SfPicker
    {

        #region Public Properties
        internal Dictionary<string, string> Months { get; set; }
        public ObservableCollection<object> Date { get; set; }
        internal ObservableCollection<object> Day { get; set; }
        internal ObservableCollection<object> Month { get; set; }
        internal ObservableCollection<object> Year { get; set; }
        public ObservableCollection<string> Headers { get; set; }


        #endregion

        public CustomDatePicker()
        {
            Months = new Dictionary<string, string>();
            Date = new ObservableCollection<object>();
            Day = new ObservableCollection<object>();
            Month = new ObservableCollection<object>();
            Year = new ObservableCollection<object>();

            PopulateDateCollection();
            this.ItemsSource = Date;
            this.SelectionChanged += CustomDatePicker_SelectionChanged;

            Headers = new ObservableCollection<string>();
            Headers.Add("Mês");
            Headers.Add("Dia");

            this.ColumnHeaderText = Headers;

            HeaderText = "Dia do Aniversário";

            ShowFooter = true;
            ShowHeader = true;
            ShowColumnHeader = true;
        }

        private void CustomDatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDays(Date, e);
        }

        public void UpdateDays(ObservableCollection<object> Date, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    bool update = false;
                    if (e.OldValue != null && e.NewValue != null && (e.OldValue as IList).Count > 0 && (e.NewValue as IList).Count > 0)
                    {
                        if ((e.OldValue as IList)[0] != (e.NewValue as IList)[0])
                        {
                            update = true;
                        }
                    }
                    if (update)
                    {
                        ObservableCollection<object> days = new ObservableCollection<object>();

                        CultureInfo currentCulture = new CultureInfo("pt-BR");
                        int month = DateTime.ParseExact(Months[(e.NewValue as IList)[0].ToString()], "MMMM", currentCulture).Month;

                        DateTime Current = DateTime.Now;
                        int year = Current.Year;
                        for (int j = 1; j <= DateTime.DaysInMonth(year, month); j++)
                        {
                            if (j < 10)
                            {
                                days.Add("0" + j);
                            }
                            else
                                days.Add(j.ToString());
                        }
                        if (days.Count > 0)
                        {
                            Date.RemoveAt(1);
                            Date.Insert(1, days);
                        }
                    }
                }
                catch{}
            });
        }


        private void PopulateDateCollection()
        {
            for (int i = 1; i < 13; i++)
            {
                if (!Months.ContainsKey(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3)))
                    Months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                Month.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3));
            }
            for (int i = 1990; i < 2050; i++)
            {
                Year.Add(i.ToString());
            }

            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                if (i < 10)

                {
                    Day.Add("0" + i);
                }
                else

                    Day.Add(i.ToString());
            }
            Date.Add(Month);
            Date.Add(Day);
        }
    }
}
