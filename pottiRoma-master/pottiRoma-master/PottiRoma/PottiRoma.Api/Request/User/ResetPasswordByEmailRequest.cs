using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.User
{
    public class ResetPasswordByEmailRequest
    {
        public string Email { get; set; }
    }
}