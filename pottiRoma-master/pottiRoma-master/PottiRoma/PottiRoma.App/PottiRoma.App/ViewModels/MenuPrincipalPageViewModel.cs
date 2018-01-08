using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels
{
    public class MenuPrincipalPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToInviteFlowerCommand { get; set; }
        public DelegateCommand GoToRankingCommand { get; set; }
        public DelegateCommand GoToProfileCommand { get; set; }
        public DelegateCommand GoToMySalesCommand { get; set; }
        public DelegateCommand GoToRegisterClientsCommand { get; set; }

        public MenuPrincipalPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToInviteFlowerCommand = new DelegateCommand(GoToInviteFlower).ObservesCanExecute(() => CanExecute);
            GoToRankingCommand = new DelegateCommand(GoToRanking).ObservesCanExecute(() => CanExecute);
            GoToProfileCommand = new DelegateCommand(GoToProfile).ObservesCanExecute(() => CanExecute);
            GoToMySalesCommand = new DelegateCommand(GoToMySales).ObservesCanExecute(() => CanExecute);
            GoToRegisterClientsCommand = new DelegateCommand(GoToRegisterClients).ObservesCanExecute(() => CanExecute);
        }

        private async void GoToRegisterClients()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.RegisterClients);
            CanExecuteEnd();
        }

        private async void GoToMySales()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.ListClients);
            CanExecuteEnd();
        }

        private async void GoToProfile()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.TabbedProfile);
            CanExecuteEnd();
        }

        private async void GoToRanking()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.Ranking);
            CanExecuteEnd();
        }

        private async void GoToInviteFlower()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.InviteFlower);
            CanExecuteEnd();
        }
    }
}
