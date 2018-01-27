using Acr.UserDialogs;
using PottiRoma.App.Dtos;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public RankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            InitializeMockRewards();
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
