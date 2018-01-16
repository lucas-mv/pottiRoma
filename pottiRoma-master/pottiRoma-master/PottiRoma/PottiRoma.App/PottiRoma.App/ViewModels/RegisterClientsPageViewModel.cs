using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Clients;
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
using Xamarin.Forms;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RegisterClientsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IClientsAppService _clientsAppService;

        private readonly string DatePlaceholder = "Data de Aniversário";
        private Color _colorDateAnniversary;
        public Color ColorDateAnniversary
        {
            get { return _colorDateAnniversary; }
            set { SetProperty(ref _colorDateAnniversary, value); }
        }

        public DelegateCommand OpenPopupDateCommand { get; set; }
        public DelegateCommand RegisterNewClientCommand { get; set; }

        private string _anniversaryDate;
        public string AnniversaryDate
        {
            get { return _anniversaryDate; }
            set { SetProperty(ref _anniversaryDate, value); }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private Client _clientSelectedForEdition;
        public Client ClientSelectedForEdition
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

        public RegisterClientsPageViewModel(
            INavigationService navigationService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _clientsAppService = clientsAppService;

            ClientSelectedForEdition = new Client();
            OpenPopupDateCommand = new DelegateCommand(OpenDatePopup).ObservesCanExecute(() => CanExecute);
            RegisterNewClientCommand = new DelegateCommand(RegisterNewClient).ObservesCanExecute(() => CanExecute);
            AnniversaryDate = DatePlaceholder;
            ColorDateAnniversary = Color.FromHex("#d5d5d5");
            PageTitle = SetTitle();
        }

        private async void OpenDatePopup()
        {
            CanExecuteInitial();
            await GetDatePopupHelper.Mostrar(CallbackDate);
            CanExecuteEnd();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationKeyParameters.EditClient))
            {
                RegisterOrEditText = "EDITAR";
                if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
                    ClientSelectedForEdition = parameters[NavigationKeyParameters.SelectedClient] as Client;
            }
        }

        private void CallbackDate(string date)
        {
            DateTime now = DateTime.Now;
            string[] newDate = date.Split('/');
            newDate[0] = newDate[0] == "0" ? now.Day.ToString() : newDate[0];
            newDate[1] = newDate[1] == "0" ? now.Month.ToString() : newDate[1];
            date = newDate[0] + "/" + newDate[1];
            ClientSelectedForEdition.Birthdate = new DateTime(9999, int.Parse(newDate[1]), int.Parse(newDate[0]));
            AnniversaryDate = date;
            ColorDateAnniversary = Color.FromHex("#696969");
        }

        private string SetTitle()
        {
            return Device.OS == TargetPlatform.Android ? "Cadastro de Clientes" : "";
        }

        private async void RegisterNewClient()
        {
            try
            {
                await NavigationHelper.ShowLoading();
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                await _clientsAppService.RegisterClient(new RegisterClientRequest()
                {
                    Address = string.Empty,
                    Birthdate = ClientSelectedForEdition.Birthdate,
                    Cpf = ClientSelectedForEdition.Cpf,
                    Email = ClientSelectedForEdition.Email,
                    SalespersonId = user.Salesperson.SalespersonId,
                    Name = ClientSelectedForEdition.Name,
                    Telephone = ClientSelectedForEdition.Telephone
                });
                UserDialogs.Instance.Toast("Cliente registrado com sucesso!");
                await _navigationService.GoBackAsync();
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.Toast("Não foi possível registrar o cliente.");
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
        }
    }
}
