using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Dtos;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Responses.Challenges;
using PottiRoma.App.Models.Responses.Seasons;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
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
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class RankingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IChallengesAppService _challengesAppService;
        private readonly ISeasonAppService _seasonAppService;
        private readonly ISalesAppService _salesAppService;
        private readonly IClientsAppService _clientsAppService;
        private readonly IUserAppService _userAppService;

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
        public DelegateCommand GoToCurrentChallengesPageCommand { get; set; }

        public RankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            IChallengesAppService challengesAppService,
            ISeasonAppService seasonAppService,
            IUserAppService userAppService,
            ISalesAppService salesAppService,
            IClientsAppService clientsAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _challengesAppService = challengesAppService;
            _seasonAppService = seasonAppService;
            _userAppService = userAppService;
            _salesAppService = salesAppService;
            _clientsAppService = clientsAppService;
            GoToRankingPageCommand = new DelegateCommand<RankingBannerDto>(GoToRankingPage).ObservesCanExecute(() => CanExecute);
            GoToCurrentChallengesPageCommand = new DelegateCommand(GoToCurrentChallengesPage).ObservesCanExecute(() => CanExecute);
            InitializeRankings();
        }

        private async void GoToCurrentChallengesPage()
        {
            var parameters = new NavigationParameters();
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();

            var season = new SeasonResponse();
            try
            {
                season.Entity = await CacheAccess.GetSecure<Season>(CacheKeys.SEASON_KEY);
            }
            catch
            {
                season = await _seasonAppService.CurrentSeason();
                await CacheAccess.InsertSecure<Season>(CacheKeys.SEASON_KEY, season.Entity);
            }
            bool isSuccess = true;
            var challenges = new GetCurrentChallengesResponse();

            try
            {
                challenges = await _challengesAppService.GetCurrentChallenges(season.Entity.TemporadaId.ToString());

            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível obter os desafios, verifique sua conexâo", new TimeSpan(0, 0, 3));
                isSuccess = false;
            }
            finally
            {
                challenges = SelectActualChallenges.Select(challenges);
                if (isSuccess && challenges.Challenges.Count > 0)
                {

                    parameters.Add(NavigationKeyParameters.CurrentChallenges, challenges.Challenges);
                    parameters.Add(NavigationKeyParameters.CurrentSeason, season.Entity);
                    await _navigationService.NavigateAsync(NavigationSettings.CurrentChallenges, parameters);
                }
                else
                {
                    UserDialogs.Instance.Toast("Não possuimos desafios ativos no momento!", new TimeSpan(0, 0, 3));
                }
            }
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

        private void InitializeRankings()
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
                Description = "RANKING GERAL",
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
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking2.png",
                Description = "PEÇAS POR ATENDIMENTO",
                Index = 5
            });
        }
    }
}
