using Acr.UserDialogs;
using PottiRoma.App.Models.Models;
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
    public class ListRankingPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        private ObservableCollection<User> _appUsers;
        public ObservableCollection<User> AppUsers
        {
            get { return _appUsers; }
            set { SetProperty(ref _appUsers, value); }
        }

        public ListRankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            InsertMock();
        }

        private void InsertMock()
        {
            AppUsers = new ObservableCollection<User>();
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 756,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 125,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 634,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 743,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 224,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 896,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 574,
            });

            //Aqui precisa de um script que ordena de acordo com a pontuacao

            for(int i=0; i < AppUsers.Count; i++)
            {
                AppUsers[i].RankingPosition = (i+1).ToString() + ". ";
            }
        }
    }
}
