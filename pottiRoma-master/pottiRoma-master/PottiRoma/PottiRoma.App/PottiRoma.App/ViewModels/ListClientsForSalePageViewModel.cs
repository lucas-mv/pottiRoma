using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
    public class ListClientsForSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<object> ClienteSelectedCommand { get; set; }

        public ObservableCollection<Client> ListaClientes { get; set; }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        public ListClientsForSalePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ClienteSelectedCommand = new DelegateCommand<object>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
            ListaClientes = new ObservableCollection<Client>();
        }

        private void GenerateMock()
        {
            Client mock1 = new Client
            {
                Name = "Cliente 1",
                Email = "cliente1@gmail.com",
                Telephone = "31 3248324",
            };
            Client mock2 = new Client
            {
                Name = "Cliente 5",
                Email = "cliente1@gmail.com",
                Telephone = "31 3248324",
            };
            Client mock3 = new Client
            {
                Name = "Cliente 3",
                Email = "cliente2@gmail.com",
                Telephone = "31 6456456",
            };
            Client mock4 = new Client
            {
                Name = "Cliente 4",
                Email = "cliente3@gmail.com",
                Telephone = "31 3456347",
            };
            Client mock5 = new Client
            {
                Name = "Cliente 5",
                Email = "cliente4@gmail.com",
                Telephone = "31 56433534",
            };
            Client mock6 = new Client
            {
                Name = "Cliente 6",
                Email = "cliente6@gmail.com",
                Telephone = "31 643634",
            };
            ListaClientes.Add(mock1);
            ListaClientes.Add(mock2);
            ListaClientes.Add(mock3);
            ListaClientes.Add(mock4);
            ListaClientes.Add(mock5);
            ListaClientes.Add(mock6);
        }

        private async Task SelecionarCliente(object item)
        {
            if (item == null) return;

            CanExecuteInitial();

            var param = new NavigationParameters();
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale, param);

            CanExecuteEnd();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            PageTitle = SetTitle();
            GenerateMock();
            base.OnNavigatedTo(parameters);
        }

        private string SetTitle()
        {
            return Device.OS == TargetPlatform.Android ? "Selecionar Cliente" : "";
        }
    }
}
