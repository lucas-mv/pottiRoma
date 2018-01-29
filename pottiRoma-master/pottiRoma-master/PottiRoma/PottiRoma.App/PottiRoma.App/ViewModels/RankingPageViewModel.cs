using Acr.UserDialogs;
using PottiRoma.App.Dtos;
using PottiRoma.App.Helpers;
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

        public DelegateCommand GoToRankingPageCommand { get; set; }

        public RankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            GoToRankingPageCommand = new DelegateCommand(GoToRankingPage).ObservesCanExecute(() => CanExecute);
            InitializeMockRewards();
        }

        private async void GoToRankingPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            await Task.Delay(2000);
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add(NavigationKeyParameters.RankingType, SelectedIndex);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
            await NavigationHelper.PopLoading();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _selectedIndex = 2;
        }

        private void InitializeMockRewards()
        {
            RankingDto = new ObservableCollection<RankingBannerDto>();
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "ranking_semana.png",
                Description = "TICKET MÉDIO"
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking1.png",
                Description = "CADASTRO DE CLIENTES"
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking2.png",
                Description = "PEÇAS POR ATENDIMENTO"
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking3.png",
                Description = "CADASTRO DE FLORES ALIADAS"
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "ranking_dia.png",
                Description = "VENDAS EFETUADAS"
            });
        }
    }
}
