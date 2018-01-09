using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels
{
	public class ProfileTabbedPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ProfileTabbedPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }
    }
}
