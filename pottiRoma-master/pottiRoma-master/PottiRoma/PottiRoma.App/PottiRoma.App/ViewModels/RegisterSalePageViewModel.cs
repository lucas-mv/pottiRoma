using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottiRoma.App.ViewModels
{
    public class RegisterSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand SaveSaleCommand { get; set; }

        private Sale _saleRegistered;
        public Sale SaleRegistered
        {
            get { return _saleRegistered; }
            set { SetProperty(ref _saleRegistered, value); }
        }

        private string _nameAndDateLabel;
        public string NameAndDateLabel
        {
            get { return _nameAndDateLabel; }
            set { SetProperty(ref _nameAndDateLabel, value); }
        }

        public RegisterSalePageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
            SaveSaleCommand = new DelegateCommand(SaveSale).ObservesCanExecute(() => CanExecute);
            SaleRegistered = new Sale();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
            {
                Client selectedClient = (Client)parameters[NavigationKeyParameters.SelectedClient];
                SaleRegistered.ClientId = selectedClient.ClientId;
                SaleRegistered.ClientName = selectedClient.Name;
                NameAndDateLabel = "Venda para: " + SaleRegistered.ClientName + ", " + Formatter.FormatDate(DateTime.Now);
            }
            base.OnNavigatedTo(parameters);
        }

        private bool IsSaleValid()
        {
            return (SaleRegistered.SaleValue > 0 && SaleRegistered.SalePaidValue >= 0 && !string.IsNullOrEmpty(SaleRegistered.NumberSoldPieces) && (SaleRegistered.ClientId != null)) ? true : false;
        }

        private async void SaveSale()
        {
            TimeSpan duration = new TimeSpan(0, 0, 3);

            if (IsSaleValid())
            {
                CanExecuteInitial();
                await NavigationHelper.ShowLoading();
                _userDialogs.Toast("Parabéns! Você ganhou 30 pontos!", duration);
                var teste = SaleRegistered;
                //TODO fazer servico que registra a venda do usuário         
                await Task.Delay(2000);
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                CanExecuteEnd();
                await NavigationHelper.PopLoading();
            }
            else _userDialogs.Toast("Faltam Dados para preencher!", duration);
        }

        private async void GoBack()
        {
            CanExecuteInitial();
            await _navigationService.GoBackAsync();
            CanExecuteEnd();
        }
    }
}
