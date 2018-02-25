using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
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

        private bool _noData = false;
        public bool NoData
        {
            get { return _noData; }
            set { SetProperty(ref _noData, value); }
        }

        public DelegateCommand<object> EditClientCommand { get; set; }
        public DelegateCommand<object> RemoveClientCommand { get; set; }
        public DelegateCommand RegisterNewClientCommand { get; set; }
        public ObservableCollection<Client> ListaClientes { get; set; }
        public DelegateCommand ClientSelectedCommand { get; set; }

        public MyClientsPageViewModel(
            INavigationService navigationService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _clientsAppService = clientsAppService;
            ListaClientes = new ObservableCollection<Client>();
            EditClientCommand = new DelegateCommand<object>(async param => await EditClient(param))
                .ObservesCanExecute(() => CanExecute);
            RemoveClientCommand = new DelegateCommand<object>(async param => RemoveClient(param))
                .ObservesCanExecute(() => CanExecute);
            RegisterNewClientCommand = new DelegateCommand(RegisterNewClient).ObservesCanExecute(() => CanExecute);
            ClientSelectedCommand = new DelegateCommand(ClientSelected);
        }

        private void ClientSelected()
        {
            TimeSpan duration = new TimeSpan(0, 0, 3);
            UserDialogs.Instance.Toast("Arraste para a esquerda para editar ou remover cliente!", duration);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await GetClientsFromCache();
        }

        private async Task GetClientsFromCache()
        {
            ListaClientes.Clear();
            await NavigationHelper.ShowLoading();
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var clients = await _clientsAppService.GetClientsByUserId(user.UsuarioId.ToString());

                foreach (var client in clients.Clients)
                {
                    ListaClientes.Add(client);
                }
                NoData = ListaClientes.Count < 1 ? true : false;
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível carregar os clientes");
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

        private async Task RemoveClient(object item)
        {
            await NavigationHelper.ShowLoading();
            if (item == null) return;
            try
            {
                CanExecuteInitial();
                Client removedClient = (Client)item;
                await _clientsAppService.RemoveCliente(removedClient.ClienteId.ToString());

                if (removedClient != null)
                {
                    for (int i = 0; i < ListaClientes.Count; i++)
                    {
                        if (ListaClientes[i].ClienteId == removedClient.ClienteId)
                            ListaClientes.RemoveAt(i);
                    }
                }
                UserDialogs.Instance.Toast("Cliente removido com sucesso!",new TimeSpan(0,0,2));
                Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                {
                    { InsightsPagesNames.MyClientsPage, InsightsActionNames.RemoveClient }
                });
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível remover o cliente, verifique sua conexão!");
            }
            CanExecuteEnd();
            await NavigationHelper.PopLoading();
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
