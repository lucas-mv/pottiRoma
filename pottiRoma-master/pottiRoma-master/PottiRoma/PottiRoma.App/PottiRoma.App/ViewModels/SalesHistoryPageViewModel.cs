using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using PottiRoma.App.ViewModels.Core;
using System.Linq;
using Prism.Navigation;
using Acr.UserDialogs;

namespace PottiRoma.App.ViewModels
{
	public class SalesHistoryPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public SalesHistoryPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }
	}
}
