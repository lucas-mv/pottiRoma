using PottiRoma.App.Helpers;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
    public class PopupGetDateViewModel : ViewModelBase
    {
        public ObservableCollection<string> Days { get; set; }
        public ObservableCollection<string> Months { get; set; }

        private string _actualDay;
        public string ActualDay
        {
            get { return _actualDay; }
            set { SetProperty(ref _actualDay, value); }
        }

        private string _actualMonth;
        public string ActualMonth
        {
            get { return _actualMonth; }
            set { SetProperty(ref _actualMonth, value); }
        }

        public DelegateCommand ConfirmDateCommand { get; set; }
        public DelegateCommand CancelDateCommand { get; set; }
        public PopupGetDateViewModel()
        {
            ConfirmDateCommand = new DelegateCommand(Confirm).ObservesCanExecute(() => CanExecute);
            CancelDateCommand = new DelegateCommand(Cancel).ObservesCanExecute(() => CanExecute);

            Days = FillDays(31);
            Months = FillMonths();
            SetInitialPickePositions();
        }

        private async void Confirm()
        {
            CanExecuteInitial();
            await GetDatePopupHelper.EsconderAsync();
            CanExecuteEnd();
        }

        private async void Cancel()
        {
            CanExecuteInitial();
            await GetDatePopupHelper.EsconderAsync();
            CanExecuteEnd();
        }

        private  void SetInitialPickePositions()
        {
            DateTime currentDay = DateTime.Now;

            Device.BeginInvokeOnMainThread(() => 
            {
                ActualMonth = "Junho";
                ActualDay = "15";
            });
        }

        public ObservableCollection<string> FillMonths()
        {
            ObservableCollection<string> months = new ObservableCollection<string>();
            months.Add(MonthStringFormat.Janeiro);
            months.Add(MonthStringFormat.Fevereiro);
            months.Add(MonthStringFormat.Março);
            months.Add(MonthStringFormat.Abril);
            months.Add(MonthStringFormat.Maio);
            months.Add(MonthStringFormat.Junho);
            months.Add(MonthStringFormat.Julho);
            months.Add(MonthStringFormat.Agosto);
            months.Add(MonthStringFormat.Setembro);
            months.Add(MonthStringFormat.Outubro);
            months.Add(MonthStringFormat.Novembro);
            months.Add(MonthStringFormat.Dezembro);

            return months;
        }

        public ObservableCollection<string> FillDays(int amountDays)
        {
            ObservableCollection<string> days = new ObservableCollection<string>();


            for (int i = 1; i <= amountDays; i++)
            {
                string day;
                day = i < 10 ? string.Concat("0", i.ToString()) : i.ToString();
                days.Add(day);
            }
            return days;
        }
    }
}
