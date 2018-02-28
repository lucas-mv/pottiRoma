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
    public class RankingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        private ObservableCollection<RankingBannerDto> _rankingDto;
        public ObservableCollection<RankingBannerDto> RankingDto
        {
            get { return _rankingDto; }
            set { SetProperty(ref _rankingDto, value); }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        public DelegateCommand<RankingBannerDto> GoToRankingPageCommand { get; set; }
        public DelegateCommand GoToGeneralRankingPageCommand { get; set; }

        public RankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            GoToRankingPageCommand = new DelegateCommand<RankingBannerDto>(GoToRankingPage).ObservesCanExecute(() => CanExecute);
            GoToGeneralRankingPageCommand = new DelegateCommand(GoToGeneralRankingPage).ObservesCanExecute(() => CanExecute);
            InitializeRewards();
        }

        private async void GoToGeneralRankingPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            try
            {
                Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.RankingPage, InsightsActionNames.VisualizeRanking }
                        });
            }
            catch { }
            await Task.Delay(2000);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking);
            CanExecuteEnd();
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

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            SelectedIndex = 2;
        }

        private void InitializeRewards()
        {
            RankingDto = new ObservableCollection<RankingBannerDto>();
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "ranking_semana.png",
                Description = "TICKET MÉDIO",
                Index = 0
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking1.png",
                Description = "CADASTRO DE CLIENTES",
                Index = 1
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking2.png",
                Description = "PEÇAS POR ATENDIMENTO",
                Index = 2
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking3.png",
                Description = "CONVIDAR FLORES ALIADAS",
                Index = 3
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "ranking_dia.png",
                Description = "VENDAS EFETUADAS",
                Index = 4
            });
        }
    }
}
