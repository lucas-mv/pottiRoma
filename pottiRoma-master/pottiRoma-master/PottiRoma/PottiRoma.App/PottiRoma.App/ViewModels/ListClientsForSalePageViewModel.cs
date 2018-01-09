using PottiRoma.App.Models;
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

namespace PottiRoma.App.ViewModels
{
    public class ListClientsForSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<object> ClienteSelectedCommand { get; set; }

        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public ListClientsForSalePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ClienteSelectedCommand = new DelegateCommand<object>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
            ListaClientes = new ObservableCollection<Cliente>();
            GenerateMock();
        }

        private void GenerateMock()
        {
            Cliente mock1 = new Cliente {
                Nome = "Cliente 1",
            };
            Cliente mock2 = new Cliente
            {
                Nome = "Cliente 5",
            };
            Cliente mock3 = new Cliente
            {
                Nome = "Cliente 3",
            };
            Cliente mock4 = new Cliente
            {
                Nome = "Cliente 4",
            };
            Cliente mock5 = new Cliente
            {
                Nome = "Cliente 5",
            };
            Cliente mock6 = new Cliente
            {
                Nome = "Cliente 6",
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
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale,param);

            CanExecuteEnd();
        }
    }
}
