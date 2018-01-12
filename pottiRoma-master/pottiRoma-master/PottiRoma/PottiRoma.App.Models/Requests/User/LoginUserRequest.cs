using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Requests.User
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Origin { get; set; }
    }
}
