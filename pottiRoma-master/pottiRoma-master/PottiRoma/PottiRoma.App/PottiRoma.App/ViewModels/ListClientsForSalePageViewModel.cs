using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Responses.Clients;
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
using Xamarin.Forms;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class ListClientsForSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IClientsAppService _clientAppService;

        public DelegateCommand<Client> ClienteSelectedCommand { get; set; }
        public DelegateCommand GoToRegisterClientCommand { get; set; }

        public ObservableCollection<Client> ListaClientes { get; set; }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private bool _noData = false;
        public bool NoData
        {
            get { return _noData; }
            set { SetProperty(ref _noData, value); }
        }

        public ListClientsForSalePageViewModel(INavigationService navigationService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _clientAppService = clientsAppService;
            ListaClientes = new ObservableCollection<Client>();
            ClienteSelectedCommand = new DelegateCommand<Client>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
            GoToRegisterClientCommand = new DelegateCommand(GoToRegisterClient).ObservesCanExecute(() => CanExecute);
        }

        private async void GoToRegisterClient()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.RegisterClients);
            CanExecuteEnd();
        }

        private async Task<GetClientsByUserIdResponse> TryGetClientsFromCache()
        {
            var clients = new GetClientsByUserIdResponse();
            try
            {
                clients.Clients = await CacheAccess.Get<List<Client>>(CacheKeys.CLIENTS);
            }
            catch
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                clients = await _clientAppService.GetClientsByUserId(user.UsuarioId.ToString());
                await CacheAccess.Insert<List<Client>>(CacheKeys.CLIENTS, clients.Clients);
            }
            return clients;
        }

        private async Task GetClients()
        {
            await NavigationHelper.ShowLoading();
            ListaClientes.Clear();
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

                var clients = await TryGetClientsFromCache();

                foreach (var client in clients.Clients)
                {
                    ListaClientes.Add(client);
                }
                NoData = ListaClientes.Count < 1 ? true : false;
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível carregar os clientes");
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
        }

        private async Task SelecionarCliente(Client item)
        {
            if (item == null) return;

            CanExecuteInitial();
            var param = new NavigationParameters();

            param.Add(NavigationKeyParameters.SelectedClient, (Client)item);
            await _navigationService.NavigateAsync(NavigationSettings.RegisterSale, param);

            CanExecuteEnd();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            PageTitle = "Selecionar Colecionadora";
            await GetClients();
            base.OnNavigatedTo(parameters);
        }
    }
}
