using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottiRoma.App.ViewModels
{
	public class ResetPasswordPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

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
        public ResetPasswordPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
            ChangePasswordCommand = new DelegateCommand(ChangePassword).ObservesCanExecute(() => CanExecute);

        }

        private async void ChangePassword()
        {
            TimeSpan duration = new TimeSpan(0, 0, 2);
            if (string.IsNullOrEmpty(RepeatPassword) || string.IsNullOrEmpty(Password))
                _userDialogs.Toast("Escreva a nova senha nos campos!", duration);
            else if(RepeatPassword != Password)
                _userDialogs.Toast("As senhas não são iguais!", duration);
            else
            {
                await NavigationHelper.ShowLoading();
                //AQUI VEM O SERVICO PARA ALTERAR A SENHA
                await Task.Delay(2000);
                _userDialogs.Toast("Senha Alterada com Sucesso!", duration);
                await _navigationService.GoBackAsync();
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
