using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Responses.User;
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
    public class MenuPrincipalPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IUserAppService _userAppService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand GoToInviteFlowerCommand { get; set; }
        public DelegateCommand GoToRankingCommand { get; set; }
        public DelegateCommand GoToProfileCommand { get; set; }
        public DelegateCommand GoToMySalesCommand { get; set; }
        public DelegateCommand GoToMyClientsCommand { get; set; }
        public DelegateCommand GoToEditPersonalDataCommand { get; set; }
        public DelegateCommand GoToSalesHistoryCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }


        public MenuPrincipalPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            IUserAppService userAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _userAppService = userAppService;

            GoToInviteFlowerCommand = new DelegateCommand(GoToInviteFlower).ObservesCanExecute(() => CanExecute);
            GoToRankingCommand = new DelegateCommand(GoToRanking).ObservesCanExecute(() => CanExecute);
            GoToProfileCommand = new DelegateCommand(GoToProfile).ObservesCanExecute(() => CanExecute);
            GoToMySalesCommand = new DelegateCommand(GoToMySales).ObservesCanExecute(() => CanExecute);
            GoToMyClientsCommand = new DelegateCommand(GoToMyClients).ObservesCanExecute(() => CanExecute);
            GoToEditPersonalDataCommand = new DelegateCommand(GoToEditPersonalData).ObservesCanExecute(() => CanExecute);
            GoToSalesHistoryCommand = new DelegateCommand(GoToSalesHistory).ObservesCanExecute(() => CanExecute);
            LogoutCommand = new DelegateCommand(Logout).ObservesCanExecute(() => CanExecute);

            Title = "Ranking Geral";
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            string firstAccess = "false";

            if (parameters.ContainsKey(NavigationKeyParameters.FirstAccess))
                firstAccess = parameters[NavigationKeyParameters.FirstAccess] as string;
            if (parameters.ContainsKey(NavigationKeyParameters.ClientsBirthday) && firstAccess == "true")
            {
                var listBirthdays = parameters[NavigationKeyParameters.ClientsBirthday] as ObservableCollection<Client>;
                await CacheAccess.Insert<ObservableCollection<Client>>(CacheKeys.BIRTHDAYS, listBirthdays);
                await PopupAnniversaryHelper.Mostrar(_userAppService);
            }
        }

        private async void GoToSalesHistory()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.SalesHistory);
            Title = "Histórico de Vendas";
            CanExecuteEnd();
        }

        private async void Logout()
        {
            CanExecuteInitial();
            await LogoutPopupHelper.Mostrar(_userDialogs, _navigationService, _userAppService);
            CanExecuteEnd();
        }

        private async void GoToEditPersonalData()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.EditPersonalData);
            Title = "Editar Dados Pessoais";
            CanExecuteEnd();
        }

        private async void GoToMyClients()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.MyClients);
            Title = "Meus Cliente";
            CanExecuteEnd();
        }

        private async void GoToMySales()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.ListClientsForSale);
            Title = "Registrar Venda";
            CanExecuteEnd();
        }

        private async void GoToProfile()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.GamificationRules);
            Title = "Regras do Jogo";
            CanExecuteEnd();
        }

        private async void GoToRanking()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.RankingDetail);
            Title = "Ranking Geral";
            CanExecuteEnd();
        }

        private async void GoToInviteFlower()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.InviteFlower);
            Title = "Convidar Flor";
            CanExecuteEnd();
        }
    }
}
