using PottiRoma.App.Models.Models;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottiRoma.App.ViewModels
{
    public class ListClientsForSalePageViewModel : ViewModelBase
    {
        public DelegateCommand<object> ClienteSelectedCommand { get; set; }

        private List<Cliente> _funcionariosObra;
        public List<Cliente> FuncionariosObra
        {
            get
            {
                return _funcionariosObra;
            }
            set
            {
                SetProperty(ref _funcionariosObra, value);
            }
        }

        public ListClientsForSalePageViewModel()
        {
            ClienteSelectedCommand = new DelegateCommand<object>(async param => await SelecionarCliente(param))
                .ObservesCanExecute(() => CanExecute);
        }

        private Task SelecionarCliente(object item)
        {
            throw new NotImplementedException();
        }
    }
}
