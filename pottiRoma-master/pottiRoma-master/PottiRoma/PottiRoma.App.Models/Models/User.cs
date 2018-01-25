using PottiRoma.App.Utils.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class User : BindableBase
    {
        public Guid UserId { get; set; }
        public UserType UserType { get; set; }
        public Salesperson Salesperson { get; set; }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _primaryTelephone;
        public string PrimaryTelephone
        {
            get { return _primaryTelephone; }
            set { SetProperty(ref _primaryTelephone, value); }
        }

        private string _secondaryTelephone;
        public string SecondaryTelephone
        {
            get { return _secondaryTelephone; }
            set { SetProperty(ref _secondaryTelephone, value); }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }
    }
}
