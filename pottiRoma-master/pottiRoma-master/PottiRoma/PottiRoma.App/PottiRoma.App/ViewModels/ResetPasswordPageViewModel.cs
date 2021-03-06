﻿using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
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
    public class ResetPasswordPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IUserAppService _userAppService;

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _repeatPassword;
        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set { SetProperty(ref _repeatPassword, value); }
        }

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand ChangePasswordCommand { get; set; }
        public ResetPasswordPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            IUserAppService userAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _userAppService = userAppService;

            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
            ChangePasswordCommand = new DelegateCommand(ChangePassword).ObservesCanExecute(() => CanExecute);
        }

        private async void ChangePassword()
        {
            try
            {
                try
                {
                    Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.ResetPasswordPage, InsightsActionNames.ChangePassword }
                        });
                }
                catch { }
                TimeSpan duration = new TimeSpan(0, 0, 3);
                if (string.IsNullOrEmpty(RepeatPassword) || string.IsNullOrEmpty(Password))
                {
                    _userDialogs.Toast("Preencha os dois campos para continuar.", duration);
                    return;
                }
                await NavigationHelper.ShowLoading();
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                await _userAppService.ChangePassword(new ChangePasswordRequest()
                {
                    NewPassword = Password,
                    OldPassword = RepeatPassword,
                    UsuarioId = user.UsuarioId
                });

                _userDialogs.Toast("Senha Alterada com Sucesso!", duration);
                await _navigationService.GoBackAsync();
                await NavigationHelper.PopLoading();
            }
            catch (Exception ex)
            {
                _userDialogs.Toast(ex.Message);
                await NavigationHelper.PopLoading();
            }
        }

        private async void GoBack()
        {
            CanExecuteInitial();
            await _navigationService.GoBackAsync();
            CanExecuteEnd();
        }
    }
}
