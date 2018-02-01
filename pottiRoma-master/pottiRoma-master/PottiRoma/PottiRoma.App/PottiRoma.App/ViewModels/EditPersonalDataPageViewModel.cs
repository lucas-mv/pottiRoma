using PottiRoma.App.Models.Models;
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

        private void MockUser()
        {
            string prefixCPF = "CPF : ";

            User = new User()
            {
                UserName = "Usuário teste",
                Cep = prefixCPF + "30310-370",
                Email = "teste@teste.com",
                PrimaryTelephone = "31 99808-6453",
                SecundaryTelephone = "31 99657-6453",
                Cpf = "182738473-90"
            };
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            MockUser();
        }
    }
}
