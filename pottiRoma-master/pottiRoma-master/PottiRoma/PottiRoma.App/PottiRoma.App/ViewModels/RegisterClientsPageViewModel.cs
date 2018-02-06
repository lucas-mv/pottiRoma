using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Helpers;
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
        private readonly IUserAppService _userAppService;
        private readonly IUserDialogs _userDialogs;

        private readonly string DatePlaceholder = "Data de Aniversário*";
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
            IClientsAppService clientsAppService,
            IUserAppService userAppService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _clientsAppService = clientsAppService;
            _userAppService = userAppService;
            _userDialogs = userDialogs;

            ClientSelectedForEdition = new Client();
            OpenPopupDateCommand = new DelegateCommand(OpenDatePopup).ObservesCanExecute(() => CanExecute);
            RegisterNewClientCommand = new DelegateCommand(RegisterNewClient).ObservesCanExecute(() => CanExecute);
            AnniversaryDate = DatePlaceholder;
            ColorDateAnniversary = Color.FromHex("#d5d5d5");
            
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
                RegisterOrEditText = "SALVAR";
                PageTitle = SetTitle(true);
                if (parameters.ContainsKey(NavigationKeyParameters.SelectedClient))
                    ClientSelectedForEdition = parameters[NavigationKeyParameters.SelectedClient] as Client;
                AnniversaryDate = Formatter.FormatDateWithoutYear(ClientSelectedForEdition.Birthdate);
                ColorDateAnniversary = Color.FromHex("#696969");
            }
            else PageTitle = SetTitle(false);
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

        private string SetTitle(bool isEdit)
        {
            if(isEdit)
                return Device.OS == TargetPlatform.Android ? "Cadastro de Clientes" : "";
            else
                return Device.OS == TargetPlatform.Android ? "Editar dados do Cliente" : "";
        }

        private async void RegisterNewClient()
        {
            if (!string.IsNullOrEmpty(ClientSelectedForEdition.Name) && !string.IsNullOrEmpty(ClientSelectedForEdition.Email) && !string.IsNullOrEmpty(ClientSelectedForEdition.Telephone) && !string.IsNullOrEmpty(ClientSelectedForEdition.Birthdate.ToString()))
            {
                try
                {
                    await NavigationHelper.ShowLoading();
                    var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    var userGuid = user.UsuarioId;
                    if (RegisterOrEditText.Contains("CADASTRAR"))
                    {
                        await _clientsAppService.RegisterClient(new RegisterClientRequest()
                        {
                            UsuarioId = userGuid,
                            Birthdate = ClientSelectedForEdition.Birthdate,
                            Cep = ClientSelectedForEdition.Cep,
                            Email = ClientSelectedForEdition.Email,
                            Name = ClientSelectedForEdition.Name,
                            Telephone = ClientSelectedForEdition.Telephone
                        });

                        int increatePoints = 50;
                        //CONSERTAR ESSE ESQUEMA
                        user.RegisterClientsPoints += 50;

                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            UsuarioId = userGuid,
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            SalesNumberPoints = user.SalesNumberPoints
                        });
                        TimeSpan duration = new TimeSpan(0, 0, 3);
                        UserDialogs.Instance.Toast("Parabéns! Você ganhou " + increatePoints + " Pontos com esse Cadastro!", duration);
                    }
                    else
                    {
                        await _clientsAppService.UpdateClientInfo(new UpdateClientInfoRequest()
                        {
                            ClienteId = ClientSelectedForEdition.ClienteId,
                            Birthdate = ClientSelectedForEdition.Birthdate,
                            Cep = ClientSelectedForEdition.Cep,
                            Email = ClientSelectedForEdition.Email,
                            Name = ClientSelectedForEdition.Name,
                            Telephone = ClientSelectedForEdition.Telephone
                        });
                        UserDialogs.Instance.Toast("Cliente editado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    if (RegisterOrEditText.Contains("CADASTRAR"))
                        UserDialogs.Instance.Toast("Não foi possível registrar o cliente.");
                    else
                        UserDialogs.Instance.Toast("Não foi possível editar o cliente.");
                }
                finally
                {
                    await NavigationHelper.PopLoading();
                    await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                }
            }
            else
            {
                TimeSpan duration = new TimeSpan(0, 0, 2);
                _userDialogs.Toast("Insira todos os dados obrigatórios.", duration);
             }
        }
    }
}
