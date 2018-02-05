using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
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

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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
            try
            {
                TimeSpan duration = new TimeSpan(0, 0, 2);
                if (string.IsNullOrEmpty(Email))
                    _userDialogs.Toast("Digite o Email!", duration);
                if (string.IsNullOrEmpty(Message))
                    _userDialogs.Toast("Digite uma mensagem!", duration);
                else
                {
                    await NavigationHelper.ShowLoading();

                    var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                    var email_name = new Dictionary<string, string>();
                    email_name.Add(Email, user.Name);
                    await _userAppService.SendEmail(new Models.Requests.User.SendEmailRequest
                    {
                        Assunto = "Convite para ser revendedor Potti Roma de" + user.Name,
                        CorpoEmail = Message,
                        Destinatarios = email_name,
                        UserId = user.UsuarioId,
                    });
                    _userDialogs.Toast("Email enviado com Sucesso!", duration);
                }
            }
            catch (Exception ex)
            {
                _userDialogs.Toast(ex.Message);
                await NavigationHelper.PopLoading();
            }
        }
    }
}
