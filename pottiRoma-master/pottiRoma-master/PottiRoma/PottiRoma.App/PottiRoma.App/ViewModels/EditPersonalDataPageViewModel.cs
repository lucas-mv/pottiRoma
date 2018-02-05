using Acr.UserDialogs;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class EditPersonalDataPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public DelegateCommand ChangePasswordCommand { get; set; }
        

        public EditPersonalDataPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ChangePasswordCommand = new DelegateCommand(ChangePassword).ObservesCanExecute(() => CanExecute);
        }

        private async void ChangePassword()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.ResetPassword, useModalNavigation: true);
            CanExecuteEnd();
        }

        private async Task GetUserFromCache()
        {
            try
            {
                User = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
            }
            catch
            {
                UserDialogs.Instance.Toast("Ocorreu um problema, faça o Login Novamente!");
            }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await GetUserFromCache();
        }
    }
}
