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

        public DelegateCommand ChangePasswordCommand { get; set; }

        public EditPersonalDataPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ChangePasswordCommand = new DelegateCommand(ChangePassword).ObservesCanExecute(() => CanExecute);
        }

        private async void ChangePassword()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.ResetPassword,useModalNavigation: true);
            CanExecuteEnd();
        }
    }
}
