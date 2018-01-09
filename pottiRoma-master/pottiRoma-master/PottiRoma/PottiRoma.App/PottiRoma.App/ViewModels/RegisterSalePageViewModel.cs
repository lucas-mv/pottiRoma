using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels
{
	public class RegisterSalePageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }

        public RegisterSalePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(GoBack).ObservesCanExecute(() => CanExecute);
        }

        private async void GoBack()
        {
            CanExecuteInitial();
            await _navigationService.GoBackAsync();
            CanExecuteEnd();
        }
    }
}
