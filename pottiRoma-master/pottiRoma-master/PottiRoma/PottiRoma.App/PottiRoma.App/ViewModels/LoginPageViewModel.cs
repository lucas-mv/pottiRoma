using Acr.UserDialogs;
using PottiRoma.App.Helpers;
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
        public DelegateCommand ResetPasswordCommand { get; set; }

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

        public LoginPageViewModel(
            INavigationService navigationService,
            IUserAppService userAppService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userAppService = userAppService;
            _userDialogs = userDialogs;

            LoginCommand = new DelegateCommand(ExecuteLogin).ObservesCanExecute(() => CanExecute);
            ResetPasswordCommand = new DelegateCommand(ResetPassword).ObservesCanExecute(() => CanExecute);

            CacheAccess.Initialize();
        }

        private void ResetPassword()
        {
            //aqui deve abrir um popup pro usuário inserir o email dele e assim reenviar outra senha para esse email
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var token = await CacheAccess.GetSecure<Guid>(CacheKeys.ACCESS_TOKEN);
                Settings.AccessToken = token.ToString();
                Settings.UserId = user.UserId.ToString();
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }
            catch
            {
                Settings.AccessToken = string.Empty;
                Settings.UserId = string.Empty;
            }
        }


        private async void ExecuteLogin()
        {
            try
            {
                CanExecuteInitial();
                await NavigationHelper.ShowLoading();

                var response = await _userAppService.Login(new LoginRequest()
                {
                    Email = Login,
                    Origin = 0,
                    Password = Password
                });
                if(response != null && response.User != null)
                {
                    await CacheAccess.InsertSecure<User>(CacheKeys.USER_KEY, response.User);
                    await CacheAccess.InsertSecure<Guid>(CacheKeys.ACCESS_TOKEN, response.Token);
                    Settings.AccessToken = response.Token.ToString();
                    Settings.UserId = response.User.UserId.ToString();
                    await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                }
                else
                {
                    TimeSpan duration = new TimeSpan(0, 0, 2);
                    _userDialogs.Toast("Login ou senha incorretos");
                    throw new Exception("Ocorreu um erro, tente novamente mais tarde.");
                }
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.Toast(ex.Message);
            }
            finally
            {
                await NavigationHelper.PopLoading();
                CanExecuteEnd();
            }
        }
    }
}
