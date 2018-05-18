using Acr.UserDialogs;
using PottiRoma.App.Helpers;
using PottiRoma.App.Models.Models;
using PottiRoma.App.Repositories.Internal;
using PottiRoma.App.Services.Interfaces;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ViewModels.Core
{
    public class PopupAnniversaryViewModel : ViewModelBase
    {
        private readonly IUserAppService _userAppService;

        private ObservableCollection<Client> _birthdays;
        public ObservableCollection<Client> Birthdays
        {
            get { return _birthdays; }
            set { SetProperty(ref _birthdays, value); }
        }

        private string _birthdayTitle;
        public string BirthdayTitle
        {
            get { return _birthdayTitle; }
            set { SetProperty(ref _birthdayTitle, value); }
        }

        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand SendEmailCommand { get; set; }

        public PopupAnniversaryViewModel(IUserAppService userAppService)
        {
            GetBirthdays();
            _userAppService = userAppService;
            CloseCommand = new DelegateCommand(Close).ObservesCanExecute(() => CanExecute);
            SendEmailCommand = new DelegateCommand(SendEmail).ObservesCanExecute(() => CanExecute);
        }

        private async void Close()
        {
            CanExecuteInitial();
            await PopupAnniversaryHelper.EsconderAsync();
            CanExecuteEnd();
        }

        private async void SendEmail()
        {
            CanExecuteInitial();

            try
            {
                var user = await CacheAccess.GetSecure<User>(CacheKeys.USER_KEY);
                foreach (var client in Birthdays)
                {
                    await _userAppService.SendBirthdayEmail(client.Email, user.Name);
                }
                UserDialogs.Instance.Toast("Email(s) enviado(s) com sucesso!");
                await PopupAnniversaryHelper.EsconderAsync();
            }
            catch
            {
                UserDialogs.Instance.Toast("Não foi possível enviar os emails, verifique sua conexão.");
            }
            finally
            {
                await NavigationHelper.PopLoading();
            }
            CanExecuteEnd();
        }

        private async void GetBirthdays()
        {
            try
            {
                Birthdays = await CacheAccess.Get<ObservableCollection<Client>>(CacheKeys.BIRTHDAYS);
            }
            catch { }
            BirthdayTitle = "Aniversariantes do dia: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "!";
        }
    }
}
