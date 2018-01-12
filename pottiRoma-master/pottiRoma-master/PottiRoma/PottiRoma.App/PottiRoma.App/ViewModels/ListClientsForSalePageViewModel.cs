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

        public ObservableCollection<Cliente> ListaClientes { get; set; }

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
            ListaClientes = new ObservableCollection<Cliente>();
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
