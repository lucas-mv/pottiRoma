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
            try
            {
                await NavigationHelper.ShowLoading();
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                if (user.Salesperson != null)
                {
                    var response = await _clientsAppService.GetClientsBySalespersonId(user.Salesperson.SalespersonId.ToString());
                    if (response == null || response.Clients == null)
                        throw new Exception("Ocorreu um erro, tente novamente mais tarde.");
                    ListaClientes = new ObservableCollection<Client>(response.Clients);
                }
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.Toast(ex.Message);
                await _navigationService.GoBackAsync();
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
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
                    if (ListaClientes[i].Cpf == removedClient.Cpf)
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
