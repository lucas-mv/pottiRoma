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
    public class ListClientsForSalePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<object> ClienteSelectedCommand { get; set; }

        public List<string> ListaClientes { get; set; }

        public ListClientsForSalePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ClienteSelectedCommand = new DelegateCommand<object>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
        }

        private async Task SelecionarCliente(object item)
        {
            if (item == null) return;

            CanExecuteInitial();

            var param = new NavigationParameters();
            //param.Add(NavigationKeyParameters.SelectedClient, item as Cliente);
            await _navigationService.GoBackAsync(param);

            CanExecuteEnd();
        }
    }
}
