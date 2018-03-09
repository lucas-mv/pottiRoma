using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Helpers;
using PottiRoma.App.Insights;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.Utils.NavigationHelpers;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels
{
    public class InviteFlowerPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IUserAppService _userAppService;

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _primaryTelephone;
        public string PrimaryTelephone
        {
            get { return _primaryTelephone; }
            set { SetProperty(ref _primaryTelephone, value); }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }

        public DelegateCommand SendEmailCommand { get; set; }

        public InviteFlowerPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs,
            IUserAppService userAppService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _userAppService = userAppService;

            SendEmailCommand = new DelegateCommand(SendEmail).ObservesCanExecute(() => CanExecute);
        }

        private async void SendEmail()
        {
            string MensagemPadrão = "Testando o envio de email";

            try
            {
                TimeSpan duration = new TimeSpan(0, 0, 2);
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Cpf) || string.IsNullOrEmpty(PrimaryTelephone))
                    _userDialogs.Toast("Dados Incompletos!", duration);

                else
                {
                    await NavigationHelper.ShowLoading();

                    var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    var userGuid = user.UsuarioId;

                    var email_name = new Dictionary<string, string>();
                    email_name.Add(Email, user.Name);
                    await _userAppService.SendEmail(Email, Name, user.Name, Cpf, PrimaryTelephone, Cep);
                    var points = await CacheAccess.GetSecure<Points>(CacheKeys.POINTS);
                    user.InviteAllyFlowersPoints += points.InviteFlower;

                    await _userAppService.UpdateUserPoints(new UpdateUserPointsRequest()
                    {
                        UsuarioId = userGuid,
                        AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                        AverageTicketPoints = user.AverageTicketPoints,
                        RegisterClientsPoints = user.RegisterClientsPoints,
                        InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                        SalesNumberPoints = user.SalesNumberPoints
                    });
                    try
                    {
                        Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
                        {
                            { InsightsPagesNames.LoginPage, InsightsActionNames.ForgotPassword }
                        });
                    }
                    catch { }
                    _userDialogs.Toast("Email enviado com Sucesso! Você ganhou " + points.InviteFlower + " Sementes com o convite!", duration);
                }
            }
            catch (Exception ex)
            {
                _userDialogs.Toast("Não foi possível enviar o convite, verifique sua conexão com a internet!");
            }
            finally
            {
                await NavigationHelper.PopLoading();
                await _navigationService.NavigateAsync(NavigationSettings.MenuPrincipal);
            }
        }
    }
}
