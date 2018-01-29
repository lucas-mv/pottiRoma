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
using PottiRoma.App.Utils.Helpers;

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
            SalesList = new ObservableCollection<Sale>();
            var mock1 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                ClientName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock2 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                ClientName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock3 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                ClientName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock4 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                ClientName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            var mock5 = new Sale()
            {
                SaleDate = new DateTime(1990, 11, 08),
                ClientName = "Lucas Roscoe",
                SaleValue = "R$ 250,00",
            };
            SalesList.Add(mock1);
            SalesList.Add(mock2);
            SalesList.Add(mock3);
            SalesList.Add(mock4);
            SalesList.Add(mock5);

            foreach (var Sale in SalesList)
            {
                CompleteLabelFromSale(Sale);
            }
        }

        private void CompleteLabelFromSale(Sale Sale)
        {
            Sale.CardLabel = Sale.ClientName + ", " + Formatter.FormatDate(Sale.SaleDate);
        }
    }
}
