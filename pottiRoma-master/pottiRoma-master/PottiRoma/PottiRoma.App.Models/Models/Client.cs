using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Client : BindableBase
    {
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set { SetProperty(ref _telephone, value); }
        }

        private DateTime _birthdate;
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { SetProperty(ref _birthdate, value); }
        }
    }
}
