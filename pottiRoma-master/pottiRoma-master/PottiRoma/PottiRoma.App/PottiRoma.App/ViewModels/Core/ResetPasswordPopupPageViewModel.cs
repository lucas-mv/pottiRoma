using PottiRoma.App.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels.Core
{
	public class ResetPasswordPopupPageViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public DelegateCommand ConfirmCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public ResetPasswordPopupPageViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm).ObservesCanExecute(() => CanExecute);
            CancelCommand = new DelegateCommand(Cancel).ObservesCanExecute(() => CanExecute);
        }

        private async void Confirm()
        {
            CanExecuteInitial();
            await ResetPasswordPopupHelper.EsconderAsync();
            CanExecuteEnd();
        }

        private async void Cancel()
        {
            CanExecuteInitial();
            await ResetPasswordPopupHelper.EsconderAsync();
            CanExecuteEnd();
        }
    }
}
