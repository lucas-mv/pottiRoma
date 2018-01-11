using PottiRoma.App.Helpers;
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
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
    public class RegisterClientsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand OpenPopupDateCommand { get; set; }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private Cliente _clientSelectedForEdition;
        public Cliente ClientSelectedForEdition
        {
            get { return _clientSelectedForEdition; }
            set { SetProperty(ref _clientSelectedForEdition, value); }
        }

        private string _registerOrEditText = "CADASTRAR";
        public string RegisterOrEditText
        {
            get { return _registerOrEditText; }
            set { SetProperty(ref _registerOrEditText, value); }
        }

        public RegisterClientsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ClientSelectedForEdition = new Cliente();
            OpenPopupDateCommand = new DelegateCommand(OpenDatePopup).ObservesCanExecute(() => CanExecute);
            PageTitle = SetTitle();
        }

        private async void OpenDatePopup()
        {
            CanExecuteInitial();
            await GetDatePopupHelper.Mostrar();
            CanExecuteEnd();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationKeyParameters.EditClient))
            {
                RegisterOrEditText = "EDITAR";
                if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
                    ClientSelectedForEdition = parameters[NavigationKeyParameters.SelectedClient] as Cliente;
            }
        }

        private string SetTitle()
        {
            return Device.OS == TargetPlatform.Android ? "Cadastro de Clientes" : ""; 
        }
    }
}
