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

namespace PottiRoma.App.ViewModels
{
	public class SalesHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISalesAppService _salesAppService;

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
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale);
            CanExecuteEnd();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await NavigationHelper.ShowLoading();

            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var salesResponse = await _salesAppService.GetSalesByUserId(user.UsuarioId.ToString());
                SalesList = new ObservableCollection<Sale>(salesResponse.Sales);
                foreach (var sale in SalesList)
                {
                    sale.CardLabel = sale.ClientName + ", " + sale.SaleDate.ToString("dd/MM/yyyy");
                }
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
