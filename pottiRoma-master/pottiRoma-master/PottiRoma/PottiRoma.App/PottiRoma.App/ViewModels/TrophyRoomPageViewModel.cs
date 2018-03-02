using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Dtos;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Utils.Enums;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PottiRoma.App.ViewModels
{
	public class TrophyRoomPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        private ObservableCollection<TrophyDto> _trophies;
        public ObservableCollection<TrophyDto> Trophies
        {
            get { return _trophies; }
            set { SetProperty(ref _trophies, value); }
        }

        public TrophyRoomPageViewModel(INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            InitializeRewards();
        }


        private async void GoToGeneralRankingPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();

            await _navigationService.NavigateAsync(NavigationSettings.TrophyRoom);
            CanExecuteEnd();
            await NavigationHelper.PopLoading();
        }

        private async void GoToRankingPage(RankingBannerDto obj)
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            await Task.Delay(2000);
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType convertedIndex = ConvertIndexToEnumHelper.Convert(obj.Index);
            parameters.Add(NavigationKeyParameters.RankingType, convertedIndex);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }


        private void InitializeRewards()
        {
            Trophies = new ObservableCollection<TrophyDto>();
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
            Trophies.Add(new TrophyDto()
            {
                Image = "trofeu.png",
                Description = "Troféu de desafio de Ticket Médio cumprido na Temporada Flores do Oriente",
            });
        }
    }
}
