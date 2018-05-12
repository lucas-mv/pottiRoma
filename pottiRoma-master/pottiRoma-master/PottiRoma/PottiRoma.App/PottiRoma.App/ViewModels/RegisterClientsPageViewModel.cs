using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.Challenges;
using PottiRoma.App.Models.Responses.GamificationPoints;
using PottiRoma.App.Models.Responses.Seasons;
using PottiRoma.App.Models.Responses.Trophies;
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
using System.Threading.Tasks;
using Xamarin.Forms;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RegisterClientsPageViewModel : ViewModelBase
    {
        private readonly ISeasonAppService _seasonAppService;
        private readonly INavigationService _navigationService;
        private readonly IClientsAppService _clientsAppService;
        private readonly IUserAppService _userAppService;
        private readonly IUserDialogs _userDialogs;
        private readonly ITrophyAppService _trophyAppService;
        private readonly IChallengesAppService _challengesAppService;
        private readonly IGamificationPointsAppService _gamificationPointsAppService;

        private bool _cameFromRegisterSale = false;

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
            ISeasonAppService seasonAppService,
            ITrophyAppService trophyAppService,
            IGamificationPointsAppService gamificationPointsAppService,
            IChallengesAppService challengesAppService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _clientsAppService = clientsAppService;
            _userAppService = userAppService;
            _trophyAppService = trophyAppService;
            _gamificationPointsAppService = gamificationPointsAppService;
            _challengesAppService = challengesAppService;
            _seasonAppService = seasonAppService;
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

            if (parameters.ContainsKey(NavigationKeyParameters.CameFromRegisterSale))
                _cameFromRegisterSale = (bool)parameters[NavigationKeyParameters.CameFromRegisterSale];
        }

        private void CallbackDate(string date)
        {
            DateTime startDate = new DateTime(9999,6,15);
            string[] newDate = date.Split('/');
            newDate[0] = newDate[0] == "0" ? startDate.Day.ToString() : newDate[0];
            newDate[1] = newDate[1] == "0" ? startDate.Month.ToString() : newDate[1];
            date = newDate[0] + "/" + newDate[1];
            ClientSelectedForEdition.Birthdate = new DateTime(9999, int.Parse(newDate[1]), int.Parse(newDate[0]));
            AnniversaryDate = date;
            ColorDateAnniversary = Color.FromHex("#696969");
        }

        private string SetTitle(bool isEdit)
        {
            string title = isEdit ? "Editar Colecionadora" : "Registrar Colecionadora";
            return title;
        }

        private bool _hasWonTrophy = false;
        private async Task GetParametersForChallenge()
        {
            var user = new User();
            var currentSeasonReponse = new SeasonResponse();
            var currentChallenges = new GetCurrentChallengesResponse();
            var myTrophies = new GetThophiesByUserIdResponse();
            user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
            try
            {
                currentSeasonReponse = await _seasonAppService.CurrentSeason();
            }
            catch
            {}
            await CheckRegisterChallengeCompleted(myTrophies.Trophies, user.UsuarioId.ToString(), currentChallenges.Challenges, currentSeasonReponse.Entity);
        }

        private async Task CheckRegisterChallengeCompleted(List<Trophy> myTrophies, string usuarioId, List<Challenge> currentChallenges, Season CurrentSeason)
        {
            try
            {
                int myRegisterPoints = 0;
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);

                try
                {
                    myRegisterPoints = await CacheAccess.Get<int>(CacheKeys.REGISTER_POINTS_FOR_CHALLENGE);
                }
                catch
                {
                    myRegisterPoints = await _clientsAppService.GetUserClientPointsForChallenge(usuarioId);
                    await CacheAccess.Insert<int>(CacheKeys.REGISTER_POINTS_FOR_CHALLENGE, myRegisterPoints);
                }

                foreach (var challenge in currentChallenges)
                {
                    bool _hasTrophy = false;
                    bool _hasEnoughtPoints = false;
                    if (challenge.Parameter == 3)
                    {
                        foreach (var trophy in myTrophies)
                        {
                            if (trophy.DesafioId.ToString() == challenge.DesafioId.ToString())
                            {
                                _hasTrophy = true;
                                break;
                            }
                        }
                        _hasEnoughtPoints = (myRegisterPoints >= challenge.Goal) ? true : false;
                    }
                    if (!_hasTrophy && _hasEnoughtPoints)
                    {
                        await _trophyAppService.InsertNewTrophy(new InsertTrophyRequest
                        {
                            DesafioId = challenge.DesafioId,
                            EndDate = challenge.EndDate,
                            StartDate = challenge.StartDate,
                            Goal = challenge.Goal,
                            Name = challenge.Name,
                            Parameter = challenge.Parameter,
                            TemporadaId = CurrentSeason.TemporadaId,
                            UsuarioId = new Guid(usuarioId),
                            Prize = challenge.Prize
                        });
                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints + challenge.Prize,
                            SalesNumberPoints = user.SalesNumberPoints,
                            UsuarioId = user.UsuarioId
                        });
                        _hasWonTrophy = true;
                        UserDialogs.Instance.Toast("Você acabou de ganhar um Troféu de Cadastro de Clientes! Parabéns!", new TimeSpan(0, 0, 4));
                    }
                }
            }
            catch { }

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

                        var myClients = await _clientsAppService.GetClientsByUserId(user.UsuarioId.ToString());
                        await CacheAccess.Insert<List<Client>>(CacheKeys.CLIENTS, myClients.Clients);

                        var points = new GetGamificationPointsResponse();
                        try
                        {
                            points.Entity = await CacheAccess.GetSecure<Points>(CacheKeys.POINTS);
                        }
                        catch
                        {
                            points = await _gamificationPointsAppService.GetCurrentGamificationPoints();
                            await CacheAccess.InsertSecure<Points>(CacheKeys.POINTS, points.Entity);
                        }
                        user.RegisterClientsPoints += points.Entity.RegisterNewClients;

                        await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                        {
                            UsuarioId = userGuid,
                            AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                            AverageTicketPoints = user.AverageTicketPoints,
                            RegisterClientsPoints = user.RegisterClientsPoints,
                            InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                            SalesNumberPoints = user.SalesNumberPoints
                        });
                        await GetParametersForChallenge();
                        TimeSpan duration = new TimeSpan(0, 0, 3);
                        if(!_hasWonTrophy)
                            UserDialogs.Instance.Toast("Parabéns! Você ganhou " + points.Entity.RegisterNewClients + " Sementes com esse Cadastro!", duration);
                        try
                        {
                            Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                            {
                                { InsightsPagesNames.RegisterClientsPage, InsightsActionNames.AddNewClient }
                            });
                        }
                        catch { }
                    }
                    else
                    {
                        try
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
                            var myClients = await _clientsAppService.GetClientsByUserId(user.UsuarioId.ToString());
                            await CacheAccess.Insert<List<Client>>(CacheKeys.CLIENTS, myClients.Clients);
                        }
                        catch
                        {
                            UserDialogs.Instance.Toast("Não foi possível editar sua cliente, verifique sua conexão!");
                        }
                        UserDialogs.Instance.Toast("Colecionadora editada com sucesso!");
                        try
                        {
                            Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                            {
                                { InsightsPagesNames.RegisterClientsPage, InsightsActionNames.EditClient }
                            });
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    if (RegisterOrEditText.Contains("CADASTRAR"))
                        UserDialogs.Instance.Toast(ex.Message);
                    else
                        UserDialogs.Instance.Toast("Não foi possível editar a Colecionadora.");
                }
                finally
                {
                    await NavigationHelper.PopLoading();
                    if (!_cameFromRegisterSale)
                        await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                    else
                        await _navigationService.GoBackAsync();
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
