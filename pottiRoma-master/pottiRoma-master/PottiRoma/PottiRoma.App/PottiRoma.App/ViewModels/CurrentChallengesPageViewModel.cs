using Acr.UserDialogs;
using PottiRoma.App.Helpers;
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
        private readonly ISalesAppService _salesAppService;
        private readonly IClientsAppService _clientsAppService;

        private ObservableCollection<Challenge> _challenges;
        public ObservableCollection<Challenge> Challenges
        {
            get { return _challenges; }
            set { SetProperty(ref _challenges, value); }
        }

        public CurrentChallengesPageViewModel(ITrophyAppService trophyAppService,
            IUserAppService userAppService,
            ISalesAppService salesAppService,
            IClientsAppService clientsAppService)
        {
            _userAppService = userAppService;
            _trophyAppService = trophyAppService;
            _salesAppService = salesAppService;
            _clientsAppService = clientsAppService;
            Challenges = new ObservableCollection<Challenge>();
        }

        int invitePoints = 0;
        int registerPoints = 0;
        int salesPoints = 0;
        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                invitePoints = await _userAppService.GetUserInvitePointsForChallenge(user.UsuarioId.ToString());
                registerPoints = await _clientsAppService.GetUserClientPointsForChallenge(user.UsuarioId.ToString());
                salesPoints = await _salesAppService.GetUserSalePointsForChallenge(user.UsuarioId.ToString());
            }
            catch
            {
                await NavigationService.GoBackAsync();
                UserDialogs.Instance.Toast("Não foi possivel carregar os desafios, verifique sua conexão.");
            }

            if (parameters.ContainsKey(NavigationKeyParameters.CurrentChallenges))
            {
                foreach (var challenge in ((List<Challenge>)parameters[NavigationKeyParameters.CurrentChallenges]))
                {
                    Challenges.Add(challenge);
                    challenge.StartDateFormatted = Formatter.FormatDate(challenge.StartDate);
                    challenge.EndDateFormatted = Formatter.FormatDate(challenge.EndDate);
                    challenge.ParameterFormatted = Formatter.FormatChallengeType((ChallengeType)challenge.Parameter);
                    challenge.CurrentSituation = GetCurrentSituationMissingPoints((ChallengeType)challenge.Parameter, challenge.Goal);
                    challenge.PrizeFormatted = challenge.Prize.ToString() + " sementes";
                }
            }
            await NavigationHelper.PopLoading();
        }

        private int GetCurrentSituationMissingPoints(ChallengeType challengeType, int goal)
        {
            int result = 0;
            switch (challengeType)
            {
                case ChallengeType.CadastrarClientes:
                    result = goal - registerPoints;
                    if (result < 0)
                        result = 0;
                    return result;
                case ChallengeType.ConvidarFloresAliadas:
                    result = goal - invitePoints;
                    if (result < 0)
                        result = 0;
                    return result;
                case ChallengeType.NumeroVendas:
                    result = goal - salesPoints;
                    if (result < 0)
                        result = 0;
                    return result;
                default: return 0;
            }
        }
    }
}
