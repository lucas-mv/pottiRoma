using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand LoginCommand { get; set; }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _loginIncorreto = false;
        public bool LoginIncorreto
        {
            get { return _loginIncorreto; }
            set { SetProperty(ref _loginIncorreto, value); }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return _canExecuteLogin;
        }

        bool _canExecuteLogin = true;
        private async void ExecuteLogin()
        {
            if (Login == "adm" && Password == "123")
            {
                _canExecuteLogin = false;
                await _navigationService.NavigateAsync(NavigationSettings.MasterDetailRanking);
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => {
                    LoginIncorreto = true;
                });
            }
        }
    }
}
