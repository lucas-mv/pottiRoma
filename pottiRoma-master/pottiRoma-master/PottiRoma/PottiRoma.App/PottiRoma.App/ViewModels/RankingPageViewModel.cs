using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels
{
    public class RankingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private double _screenHeightRequest;
        public double ScreenHeightRequest
        {
            get { return _screenHeightRequest; }
            set { SetProperty(ref _screenHeightRequest, value); }
        }
        public RankingPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }
    }
}
