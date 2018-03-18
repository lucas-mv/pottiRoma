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
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Repositories.Internal;
using static PottiRoma.App.Utils.Constants;
using PottiRoma.App.Models.Responses.Sales;
using System.Threading.Tasks;

namespace PottiRoma.App.ViewModels
{
    public class SalesHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISalesAppService _salesAppService;

        public DelegateCommand<object> SaleSelectedCommand { get; set; }

        private bool _noData = false;
        public bool NoData
        {
            get { return _noData; }
            set { SetProperty(ref _noData, value); }
        }

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
            IUserDialogs userDialogs,
            ISalesAppService salesAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _salesAppService = salesAppService;

            SaleSelectedCommand = new DelegateCommand<object>(SaleSelected).ObservesCanExecute(() => CanExecute);
        }

        private async void SaleSelected(object obj)
        {
            CanExecuteInitial();
            var saleSelected = obj as Sale;

            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(NavigationKeyParameters.SelectedSale, saleSelected);
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale, parameters);
            CanExecuteEnd();
        }

        private async Task<GetSalesByUserIdResponse> TryGetSalesFromCache()
        {
            var sales = new GetSalesByUserIdResponse();
            try
            {
                sales.Sales = await CacheAccess.Get<List<Sale>>(CacheKeys.SALES);
            }
            catch
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                sales = await _salesAppService.GetSalesByUserId(user.UsuarioId.ToString());
                await CacheAccess.Insert<List<Sale>>(CacheKeys.SALES, sales.Sales);
            }
            return sales;
        }

        private async void AdjustColorsFromSales(List<Sale> sales)
        {
            foreach (var sale in sales)
            {
                if (sale.SaleValue > sale.SalePaidValue)
                    sale.ColorLabel = "#FF3131";

                else
                    sale.ColorLabel = "#696969";
            }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await NavigationHelper.ShowLoading();

            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var salesResponse = await TryGetSalesFromCache();
                salesResponse.Sales.OrderByDescending(sale => sale.SaleDate).ToList();

                AdjustColorsFromSales(salesResponse.Sales);

                var salesDisordered = new List<Sale>(salesResponse.Sales);
                foreach (var sale in salesDisordered)
                {
                    sale.CardLabel = sale.ClientName + ", " + sale.SaleDate.ToString("dd/MM/yyyy");
                }
                salesDisordered = salesDisordered.OrderByDescending(sale => sale.SaleDate).ToList();

                SalesList = new ObservableCollection<Sale>(salesDisordered);
                NoData = SalesList.Count < 1 ? true : false;
            }
            catch (Exception ex)
            {
                _userDialogs.Toast(ex.Message);
                await _navigationService.GoBackAsync();
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
        }        

        private void CompleteLabelFromSale(Sale Sale)
        {
            Sale.CardLabel = Sale.ClientName + ", " + Formatter.FormatDate(Sale.SaleDate);
        }
    }
}
