using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
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
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class MyClientsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IClientsAppService _clientsAppService;

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
        }

        public DelegateCommand<object> EditClientCommand { get; set; }
        public DelegateCommand<object> RemoveClientCommand { get; set; }
        public DelegateCommand RegisterNewClientCommand { get; set; }
        public ObservableCollection<Client> ListaClientes { get; set; }

        public MyClientsPageViewModel(
            INavigationService navigationService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _clientsAppService = clientsAppService;

            EditClientCommand = new DelegateCommand<object>(async param => await EditClient(param))
                .ObservesCanExecute(() => CanExecute);
            RemoveClientCommand = new DelegateCommand<object>(param => RemoveClient(param))
                .ObservesCanExecute(() => CanExecute);
            RegisterNewClientCommand = new DelegateCommand(RegisterNewClient).ObservesCanExecute(() => CanExecute);
            ListaClientes = new ObservableCollection<Client>();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);


            //TODO verificar esse metodo porque esta dando null pointer no user.salesPerson

            //try
            //{
            //    await NavigationHelper.ShowLoading();
            //    var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
            //    if (user.Salesperson != null)
            //    {
            //        var response = await _clientsAppService.GetClientsBySalespersonId(user.Salesperson.SalespersonId.ToString());
            //        if (response == null || response.Clients == null)
            //            throw new Exception("Ocorreu um erro, tente novamente mais tarde.");
            //        ListaClientes = new ObservableCollection<Client>(response.Clients);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    UserDialogs.Instance.Toast(ex.Message);
            //    await _navigationService.GoBackAsync();
            //}
            //finally
            //{
            //    await NavigationHelper.PopLoading();
            //}


            MockClients();
        }

        private void MockClients()
        {
            ListaClientes.Add(new Client
            {
                Birthdate = new DateTime(1990,11,08),
                Name = "Lucas Roscoe",
                Cep = "109472066-63",
                ClientId = Guid.NewGuid(),
                Email = "lucasrloliveira@gmail.com",
                Telephone = "998085147",
            });
            ListaClientes.Add(new Client
            {
                Birthdate = new DateTime(1989, 8, 25),
                Name = "Maria Clara Diniz",
                Cep = "109549066-45",
                ClientId = Guid.NewGuid(),
                Email = "lucasrloliveira@gmail.com",
                Telephone = "998986521",
            });
            ListaClientes.Add(new Client
            {
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Laura Diniz",
                Cep = "367472066-33",
                ClientId = Guid.NewGuid(),
                Email = "Lauradiniz@gmail.com",
                Telephone = "985748526",
            });
            ListaClientes.Add(new Client
            {
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Luisa Antunes",
                Cep = "685956874-12",
                ClientId = Guid.NewGuid(),
                Email = "luisa_antunes@gmail.com",
                Telephone = "987545852",
            });
            ListaClientes.Add(new Client
            {
                Birthdate = new DateTime(1990, 11, 08),
                Name = "Davi Ferraz",
                Cep = "521478596-12",
                ClientId = Guid.NewGuid(),
                Email = "davi_ferraz@gmail.com",
                Telephone = "985623165",
            });
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
            Client removedClient = (Client)item;
            if (removedClient != null)
            {
                for (int i = 0; i < ListaClientes.Count; i++)
                {
                    if (ListaClientes[i].ClientId == removedClient.ClientId)
                        ListaClientes.RemoveAt(i);
                }
            }
            CanExecuteEnd();
        }

        private async Task EditClient(object item)
        {
            if (item == null) return;

            CanExecuteInitial();
            Client selectedClient = (Client)item;
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
