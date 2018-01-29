using Acr.UserDialogs;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Utils.Enums;
using PottiRoma.App.Utils.NavigationHelpers;
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
        private CarouselBannerType ListType;
        private ObservableCollection<User> _appUsers;
        public ObservableCollection<User> AppUsers
        {
            get { return _appUsers; }
            set { SetProperty(ref _appUsers, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ListRankingPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        private void InsertPageTitleAndPoints()
        {
            switch (ListType)
            {
                case CarouselBannerType.AverageTicket:
                    Title = "Ticket Médio";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.AverageTicketPoints;
                    break;
                case CarouselBannerType.RegisterClients:
                    Title = "Cadastro de Clientes";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.RegisterNewClientsPoints;
                    break;
                case CarouselBannerType.AveragePiecesForSale:
                    Title = "Peças por Venda";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.AverageItensPerSalePoints;
                    break;
                case CarouselBannerType.RegisterAlliedFlowers:
                    Title = "Registro de Flores Aliadas";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.InviteAllyFlowersPoints;
                    break;
                case CarouselBannerType.RegisteredSales:
                    Title = "Registro de Vendas";
                    foreach (var users in AppUsers)
                        users.TotalPoints = users.SalesNumberPoints;
                    break;
                case CarouselBannerType.Total:
                    Title = "Geral";
                    break;
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            InsertMock();

            if (parameters.ContainsKey(NavigationKeyParameters.RankingType))
                ListType = (CarouselBannerType)parameters[NavigationKeyParameters.RankingType];
            else ListType = CarouselBannerType.Total;

            InsertPageTitleAndPoints();
            base.OnNavigatedTo(parameters);
        }

        private void InsertMock()
        {
            AppUsers = new ObservableCollection<User>();
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 756,
                AverageItensPerSalePoints = 345,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 125,
                AverageItensPerSalePoints = 754,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 634,
                AverageItensPerSalePoints = 445,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 743,
                AverageItensPerSalePoints = 468,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 224,
                AverageItensPerSalePoints = 256,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 896,
                AverageItensPerSalePoints = 648,
            });
            AppUsers.Add(new User
            {
                UserName = "Lucas Roscoe",
                TotalPoints = 574,
                AverageItensPerSalePoints = 457,
            });

            //Aqui precisa de um script que ordena de acordo com a pontuacao

            for(int i=0; i < AppUsers.Count; i++)
            {
                AppUsers[i].RankingPosition = (i+1).ToString() + ". ";
            }
        }
    }
}
