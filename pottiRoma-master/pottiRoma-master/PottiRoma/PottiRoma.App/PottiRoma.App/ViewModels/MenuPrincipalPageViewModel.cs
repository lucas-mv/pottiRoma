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
            GoToInviteFlowerCommand = new DelegateCommand(GoToInviteFlower, CanAlwaysNavigate);
            GoToRankingCommand = new DelegateCommand(GoToRanking, CanAlwaysNavigate);
            GoToProfileCommand = new DelegateCommand(GoToProfile, CanAlwaysNavigate);
            GoToMySalesCommand = new DelegateCommand(GoToMySales, CanAlwaysNavigate);
            GoToRegisterClientsCommand = new DelegateCommand(GoToRegisterClients, CanAlwaysNavigate);
        }

        private void GoToRegisterClients()
        {
            _navigationService.NavigateAsync(NavigationSettings.RegisterClients);
        }

        private void GoToMySales()
        {
            _navigationService.NavigateAsync(NavigationSettings.MySales);
        }

        private void GoToProfile()
        {
            _navigationService.NavigateAsync(NavigationSettings.TabbedProfile);
        }

        private void GoToRanking()
        {
            _navigationService.NavigateAsync(NavigationSettings.Ranking);
        }

        private void GoToInviteFlower()
        {
            _navigationService.NavigateAsync(NavigationSettings.InviteFlower);
        }

        private bool CanAlwaysNavigate()
        {
            return true;
        }
    }
}
