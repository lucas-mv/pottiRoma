using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.User
{
    public class ChangePasswordRequest
    {
        public Guid UsuarioId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}