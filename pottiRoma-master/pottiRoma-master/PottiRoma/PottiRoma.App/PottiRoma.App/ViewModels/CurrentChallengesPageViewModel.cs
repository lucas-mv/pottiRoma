using PottiRoma.App.Models.Models;
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
	public class CurrentChallengesPageViewModel : ViewModelBase
	{
        private readonly ITrophyAppService _trophyAppService;
        private readonly IUserAppService _userAppService;

        private ObservableCollection<Challenge> _challenges;
        public ObservableCollection<Challenge> Challenges
        {
            get { return _challenges; }
            set { SetProperty(ref _challenges, value); }
        }

        public CurrentChallengesPageViewModel(ITrophyAppService trophyAppService,
            IUserAppService userAppService)
        {
            _userAppService = userAppService;
            _trophyAppService = trophyAppService;
            Challenges = new ObservableCollection<Challenge>();

            
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey(NavigationKeyParameters.CurrentChallenges))
            {
                foreach (var challenge in (List<Challenge>)parameters[NavigationKeyParameters.CurrentChallenges])
                {
                    Challenges.Add(challenge);
                    challenge.StartDateFormatted = Formatter.FormatDate(challenge.StartDate);
                    challenge.EndDateFormatted = Formatter.FormatDate(challenge.EndDate);
                    challenge.PrizeFormatted = challenge.Prize.ToString() + " pts.";
                    challenge.ParameterFormatted = Formatter.FormatChallengeType((ChallengeType)challenge.Parameter);
                }
            }
        }
    }
}
