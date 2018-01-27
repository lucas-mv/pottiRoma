using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using PottiRoma.App.ViewModels.Core;
using System.Linq;
using Prism.Navigation;
using Acr.UserDialogs;
using System.Collections.ObjectModel;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;

namespace PottiRoma.App.ViewModels
{
	public class SalesHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public DelegateCommand<object> SaleSelectedCommand { get; set; }

        private ObservableCollection<Sale> _saleList;
        public ObservableCollection<Sale> SalesList
        {
            get { return _saleList; }
            set { SetProperty(ref _saleList, value); }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        public SalesHistoryPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            SalesList = new ObservableCollection<Sale>();
            SaleSelectedCommand = new DelegateCommand<object>(SaleSelected).ObservesCanExecute(() => CanExecute);
        }

        private async void SaleSelected(object obj)
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale);
            CanExecuteEnd();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            GenerateMock();
        }

        private void GenerateMock()
        {
            var mock1 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                BuyerName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock2 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                BuyerName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock3 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                BuyerName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock4 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                BuyerName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock5 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                BuyerName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
        }

        private void CompleteLabelFromSale(Sale Sale)
        {
            string StringDate = Sale.SaleDate.ToString();
            string FormattedDate = Convert.ToDateTime(StringDate).ToString("yyyy-MM-dd");
            Sale.CardLabel = Sale.BuyerName + ", " + FormattedDate;
        }
    }
}
