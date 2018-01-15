using Acr.UserDialogs;
using PottiRoma.App.Dtos;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
    public class TrophyRoomPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        private ObservableCollection<TrophyRewardsDto> _rewardDto;
        public ObservableCollection<TrophyRewardsDto> RewardDto
        {
            get { return _rewardDto; }
            set { SetProperty(ref _rewardDto, value); }
        }

        public TrophyRoomPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;

            InitializeMockRewards();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        private void InitializeMockRewards()
        {
            RewardDto = new ObservableCollection<TrophyRewardsDto>();
            RewardDto.Add(new TrophyRewardsDto()
            {
                Image = "award_1.png",
                Description = "Lorem ipsum blandit ullamcorper nunc eleifend inceptos in ligula dictum sit habitant"
            });
            RewardDto.Add(new TrophyRewardsDto()
            {
                Image = "award_2.png",
                Description = "Lorem ipsum blandit ullamcorper nunc eleifend inceptos in ligula dictum sit habitant"
            });
            RewardDto.Add(new TrophyRewardsDto()
            {
                Image = "award_3.png",
                Description = "Lorem ipsum blandit ullamcorper nunc eleifend inceptos in ligula dictum sit habitant"
            });
            RewardDto.Add(new TrophyRewardsDto()
            {
                Image = "award_3.png",
                Description = "Lorem ipsum blandit ullamcorper nunc eleifend inceptos in ligula dictum sit habitant"
            });

        }
    }
}
