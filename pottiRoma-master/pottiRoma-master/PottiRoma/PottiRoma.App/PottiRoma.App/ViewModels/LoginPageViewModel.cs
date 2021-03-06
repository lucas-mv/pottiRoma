﻿using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
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
        private readonly IChallengesAppService _challengesAppService;
        private readonly ISeasonAppService _seasonAppService;
        private readonly ISalesAppService _salesAppService;
        private readonly IClientsAppService _clientsAppService;


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
            IUserDialogs userDialogs,
            IChallengesAppService challengesAppService,
            ISeasonAppService seasonAppService,
            ISalesAppService salesAppService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _userAppService = userAppService;
            _userDialogs = userDialogs;
            _challengesAppService = challengesAppService;
            _seasonAppService = seasonAppService;
            _salesAppService = salesAppService;
            _clientsAppService = clientsAppService;

            LoginCommand = new DelegateCommand(ExecuteLogin).ObservesCanExecute(() => CanExecute);
            ResetPasswordCommand = new DelegateCommand(ResetPassword).ObservesCanExecute(() => CanExecute);

            CacheAccess.Initialize();
        }

        private async void ResetPassword()
        {
            CanExecuteInitial();
            await ResetPasswordPopupHelper.Mostrar(CallbackDate);
            CanExecuteEnd();
        }

        private async void CallbackDate(string email)
        {
            await NavigationHelper.ShowLoading();
            try
            {
                var user = await _userAppService.GetUserByEmail(email);
                await _userAppService.ResetPassword(user.UsuarioId.ToString());
                UserDialogs.Instance.Toast("Te enviamos um email com uma nova senha!");
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível realizar a requisição, verifique sua conexão e o email informado.");
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Settings.AccessToken = string.Empty;
            Settings.UserId = string.Empty;
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
                    Settings.UserId = response.User.UsuarioId.ToString();
                    await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.LoginPage, InsightsActionNames.LoginSuccess }
                        });
                    }
                    catch { }
                    var teste2 = await _salesAppService.GetUserSalePointsForChallenge(response.User.UsuarioId.ToString());
                    var teste3 = await _clientsAppService.GetUserClientPointsForChallenge(response.User.UsuarioId.ToString());
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
                Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                {
                    { InsightsPagesNames.LoginPage, InsightsActionNames.LoginFailed }
                });
                UserDialogs.Instance.Toast("Não foi possível fazer o Login, verifique sua conexão");
            }
            finally
            {
                await NavigationHelper.PopLoading();
                CanExecuteEnd();
            }
        }
    }
}
