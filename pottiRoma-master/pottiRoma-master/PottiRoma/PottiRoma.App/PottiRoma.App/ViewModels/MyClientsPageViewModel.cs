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
	public class MyClientsPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
        }

        public DelegateCommand<object> EditClientCommand { get; set; }
        public DelegateCommand<object> RemoveClientCommand { get; set; }
        public DelegateCommand RegisterNewClientCommand { get; set; }
        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public MyClientsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            EditClientCommand = new DelegateCommand<object>(async param => await EditClient(param))
                .ObservesCanExecute(() => CanExecute);
            RemoveClientCommand = new DelegateCommand<object>(param =>  RemoveClient(param))
                .ObservesCanExecute(() => CanExecute);
            RegisterNewClientCommand = new DelegateCommand(RegisterNewClient).ObservesCanExecute(() => CanExecute);
            ListaClientes = new ObservableCollection<Cliente>();
            GenerateMock();
        }

        private async void RegisterNewClient()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.RegisterClients);
            CanExecuteEnd();
        }

        private void RemoveClient(object item)
        {
            if (item == null) return;

            CanExecuteInitial();
            Cliente removedClient = (Cliente)item;
            if (removedClient != null)
            {
                for (int i=0; i < ListaClientes.Count; i++)
                {
                    if (ListaClientes[i].CPF == removedClient.CPF)
                        ListaClientes.RemoveAt(i);
                }
            }
            CanExecuteEnd();
        }

        private void GenerateMock()
        {
            Cliente mock1 = new Cliente
            {
                Nome = "Cliente 1",
                Email = "cliente1@gmail.com",
                Telefone = "31 3248324",
            };
            Cliente mock2 = new Cliente
            {
                Nome = "Cliente 5",
                Email = "cliente1@gmail.com",
                Telefone = "31 3248324",
            };
            Cliente mock3 = new Cliente
            {
                Nome = "Cliente 3",
                Email = "cliente2@gmail.com",
                Telefone = "31 6456456",
            };
            Cliente mock4 = new Cliente
            {
                Nome = "Cliente 4",
                Email = "cliente3@gmail.com",
                Telefone = "31 3456347",
            };
            Cliente mock5 = new Cliente
            {
                Nome = "Cliente 5",
                Email = "cliente4@gmail.com",
                Telefone = "31 56433534",
            };
            Cliente mock6 = new Cliente
            {
                Nome = "Cliente 6",
                Email = "cliente6@gmail.com",
                Telefone = "31 643634",
            };
            ListaClientes.Add(mock1);
            ListaClientes.Add(mock2);
            ListaClientes.Add(mock3);
            ListaClientes.Add(mock4);
            ListaClientes.Add(mock5);
            ListaClientes.Add(mock6);
        }

        private async Task EditClient(object item)
        {
            if (item == null) return;

            CanExecuteInitial();
            Cliente selectedClient = (Cliente)item;
            if (selectedClient != null)
            {
                var param = new NavigationParameters();
                param.Add(NavigationKeyParameters.EditClient, "EDITAR CLIENTE");
                param.Add(NavigationKeyParameters.SelectedClient, selectedClient);
                await _navigationService.NavigateAsync(NavigationSettings.RegisterClients, param);
            }
            CanExecuteEnd();
        }
    }
}
