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
        public DelegateCommand GoToAvgTicketPageCommand { get; set; }
        public DelegateCommand GoToRegisterClientsPageCommand { get; set; }
        public DelegateCommand GoToGeneralRankingPageCommand { get; set; }
        public DelegateCommand GoToInviteFlowerPageCommand { get; set; }
        public DelegateCommand GoToEffectedSalesPageCommand { get; set; }
        public DelegateCommand GoToAvgPiecesForSalePageCommand { get; set; }

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
            GoToAvgPiecesForSalePageCommand = new DelegateCommand(GoToAvgPiecesForSalePage).ObservesCanExecute(() => CanExecute);
            GoToAvgTicketPageCommand = new DelegateCommand(GoToAvgTicketPage).ObservesCanExecute(() => CanExecute);
            GoToEffectedSalesPageCommand = new DelegateCommand(GoToEffectedSalesPage).ObservesCanExecute(() => CanExecute);
            GoToGeneralRankingPageCommand = new DelegateCommand(GoToGeneralRankingPage).ObservesCanExecute(() => CanExecute);
            GoToInviteFlowerPageCommand = new DelegateCommand(GoToInviteFlowerPage).ObservesCanExecute(() => CanExecute);
            GoToRegisterClientsPageCommand = new DelegateCommand(GoToRegisterClientsPage).ObservesCanExecute(() => CanExecute);
            InitializeRankings();
        }

        private async void GoToGeneralRankingPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.Total;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToAvgPiecesForSalePage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.AveragePiecesForSale;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToAvgTicketPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.AverageTicket;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToEffectedSalesPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.RegisteredSales;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToInviteFlowerPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.RegisterAlliedFlowers;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToRegisterClientsPage()
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
            NavigationParameters parameters = new NavigationParameters();
            CarouselBannerType rankingType = CarouselBannerType.RegisterClients;
            parameters.Add(NavigationKeyParameters.RankingType, rankingType);
            await _navigationService.NavigateAsync(NavigationSettings.ListRanking, parameters);
            CanExecuteEnd();
        }

        private async void GoToCurrentChallengesPage()
        {
            var parameters = new NavigationParameters();
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();

            var season = new SeasonResponse();
            bool isSuccess = true;
            var challenges = new GetCurrentChallengesResponse();

            try
            {
                season = await _seasonAppService.CurrentSeason();
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
            await NavigationHelper.PopLoading();
            CanExecuteEnd();
        }


        private async void GoToRankingPage(RankingBannerDto obj)
        {
            CanExecuteInitial();
            await NavigationHelper.ShowLoading();
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
                Image = "ranking_ticket.png",
                Description = "TICKET MÉDIO",
                Index = 0
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "rank_cadastro_colecionadora.png",
                Description = "CADASTRO DE CLIENTES",
                Index = 1
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "banner_ranking_geral.png",
                Description = "RANKING GERAL",
                Index = 2
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "rank_cadastro_flor_aliada.png",
                Description = "CONVIDAR FLORES ALIADAS",
                Index = 3
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "ranking_atendimento.png",
                Description = "VENDAS EFETUADAS",
                Index = 4
            });
            RankingDto.Add(new RankingBannerDto()
            {
                Image = "rank_pecas_atendimento.png",
                Description = "PEÇAS POR ATENDIMENTO",
                Index = 5
            });
        }
    }
}
