using PottiRoma.App.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Cpf { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PrimaryTelephone { get; set; }
        public string SecondaryTelphone { get; set; }
        public UserType UserType { get; set; }
    }
}
