using Acr.UserDialogs;
using Newtonsoft.Json;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserAppService _userAppService;
        private readonly IUserDialogs _userDialogs;

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
        }

        public DelegateCommand LoginCommand { get; set; }

        private string _login = "";
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password = "";
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

        public LoginPageViewModel(
            INavigationService navigationService,
            IUserAppService userAppService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userAppService = userAppService;
            _userDialogs = userDialogs;

            LoginCommand = new DelegateCommand(ExecuteLogin).ObservesCanExecute(() => CanExecute);

            CacheAccess.Initialize();
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var token = await CacheAccess.GetSecure<Guid>(CacheKeys.ACCESS_TOKEN);
                Settings.UserId = user.UserId.ToString();
                Settings.AccessToken = token.ToString();
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }
            catch
            {
            }
        }

        private async void ExecuteLogin()
        {
            CanExecuteInitial();

            try
            {
                var request = new LoginUserRequest()
                {
                    Email = Login,
                    Password = Password,
                    Origin = 0
                };
                var requestJson = JsonConvert.SerializeObject(request);
                var loginResponse = await _userAppService.Login(request);
                if(loginResponse != null && loginResponse.User != null)
                {
                    Settings.UserId = loginResponse.User.UserId.ToString();
                    Settings.AccessToken = loginResponse.Token.ToString();
                    await CacheAccess.InsertSecure<User>(CacheKeys.USER_KEY, loginResponse.User);
                    await CacheAccess.InsertSecure<Guid>(CacheKeys.ACCESS_TOKEN, loginResponse.Token);
                    await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                }
                else
                {
                    throw new Exception("Ocorreu um erro, tente novamente mais tarde.");
                }
            }
            catch(Exception ex)
            {
                LoginIncorreto = true;
                _userDialogs.Toast(ex.Message);
            }

            CanExecuteEnd();
        }
    }
}
