using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.User
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthOrigin Origin { get; set; }
    }
}