using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Dtos;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
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

        private ObservableCollection<Trophy> _myTrophies;
        public ObservableCollection<Trophy> MyTrophies
        {
            get { return _myTrophies; }
            set { SetProperty(ref _myTrophies, value); }
        }

        public TrophyRoomPageViewModel(INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;

            MyTrophies = new ObservableCollection<Trophy>();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationKeyParameters.MyTrophies))
            {
                foreach (var trophy in (List<Trophy>)parameters[NavigationKeyParameters.MyTrophies])
                {
                    MyTrophies.Add(trophy);
                    trophy.Description = "Você conseguiu o " + trophy.Name + " após realizar " +
                        trophy.Goal + " " +
                        (Formatter.FormatChallengeTypeForDescription((ChallengeType)trophy.Parameter))
                    + " durante o período entre " + Formatter.FormatDate(trophy.StartDate) + " até " + Formatter.FormatDate(trophy.EndDate);
                }
            }
        }
    }
}
