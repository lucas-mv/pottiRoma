using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Entities
{
    public class UserEntity
    {
        public Guid UserId { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PrimaryTelephone { get; set; }
        public string SecondaryTelphone { get; set; }
        public UserType UserType { get; set; }
        public SalespersonEntity Salesperson { get; set; }
    }
}
