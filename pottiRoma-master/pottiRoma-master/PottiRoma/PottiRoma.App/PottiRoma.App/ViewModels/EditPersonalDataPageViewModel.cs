using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class EditPersonalDataPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserAppService _userAppService;
        private readonly ISalesAppService _salesAppService;

        private User _user;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _profit;
        public string Profit
        {
            get { return _profit; }
            set { SetProperty(ref _profit, value); }
        }

        public DelegateCommand ChangePasswordCommand { get; set; }
        public DelegateCommand EditPersonalDataCommand { get; set; }
        

        public EditPersonalDataPageViewModel(INavigationService navigationService,
            IUserAppService userAppService,
            ISalesAppService salesAppService)
        {
            _navigationService = navigationService;
            _userAppService = userAppService;
            _salesAppService = salesAppService;
            ChangePasswordCommand = new DelegateCommand(ChangePassword).ObservesCanExecute(() => CanExecute);
            EditPersonalDataCommand = new DelegateCommand(EditPersonalData).ObservesCanExecute(() => CanExecute);
        }

        private async void EditPersonalData()
        {
            if (User.Email != null)
            {
                try
                {
                    await _userAppService.UpdateUser(User.UsuarioId.ToString(), User.Email, User.PrimaryTelephone, User.SecundaryTelephone, User.Cep);
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.EditPersonalDataPage, InsightsActionNames.EditPersonalData }
                        });
                    }
                    catch { }
                    UserDialogs.Instance.Toast("Edição de dados realizada com sucesso!");
                }
                catch
                {
                    UserDialogs.Instance.Toast("Não foi possível editar suas informações pessoais!");
                }
                finally
                {
                    await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
                }
            }
            else UserDialogs.Instance.Toast("Preencha o seu email");
        }

        private async void ChangePassword()
        {
            CanExecuteInitial();
            await _navigationService.NavigateAsync(NavigationSettings.ResetPassword, useModalNavigation: true);
            CanExecuteEnd();
        }

        private async Task GetUserFromCache()
        {
            await NavigationHelper.ShowLoading();
            try
            {
                User = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                var salesResponse = await _salesAppService.GetSalesByUserId(User.UsuarioId.ToString());
                float profit = 0;
                foreach (var sale in salesResponse.Sales)
                {
                    profit += sale.SaleValue;
                }
                Profit = Formatter.FormatMoney((decimal)profit);
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível carregar seus dados, verifique sua conexão!");
            }
            await NavigationHelper.PopLoading();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await GetUserFromCache();
        }
    }
}
