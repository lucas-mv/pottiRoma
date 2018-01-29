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
            ListaClientes = new ObservableCollection<Client>();
            ClienteSelectedCommand = new DelegateCommand<object>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
        }

        private void GenerateMock()
        {
            ListaClientes.Add(new Client
            {
                SalespersonId = Guid.NewGuid(),
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Lucas Roscoe",
                ClientId = Guid.NewGuid(),
                Email = "lucasrloliveira@gmail.com",
                Telephone = "998085147",
            });
            ListaClientes.Add(new Client
            {
                SalespersonId = Guid.NewGuid(),
                Birthdate = new DateTime(1989, 8, 25),
                Name = "Maria Clara Diniz",
                ClientId = Guid.NewGuid(),
                Email = "lucasrloliveira@gmail.com",
                Telephone = "998986521",
            });
            ListaClientes.Add(new Client
            {
                SalespersonId = Guid.NewGuid(),
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Laura Diniz",
                ClientId = Guid.NewGuid(),
                Email = "Lauradiniz@gmail.com",
                Telephone = "985748526",
            });
            ListaClientes.Add(new Client
            {
                SalespersonId = Guid.NewGuid(),
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Luisa Antunes",
                ClientId = Guid.NewGuid(),
                Email = "luisa_antunes@gmail.com",
                Telephone = "987545852",
            });
            ListaClientes.Add(new Client
            {
                SalespersonId = Guid.NewGuid(),
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Davi Ferraz",
                ClientId = Guid.NewGuid(),
                Email = "davi_ferraz@gmail.com",
                Telephone = "985623165",
            });
        }

        private async Task SelecionarCliente(object item)
        {
            if (item == null) return;

            CanExecuteInitial();
            var param = new NavigationParameters();
            param.Add(NavigationKeyParameters.SelectedClient, (Client)item);
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale, param);

            CanExecuteEnd();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            PageTitle = "Selecionar Cliente";
            GenerateMock();
            base.OnNavigatedTo(parameters);
        }
    }
}
