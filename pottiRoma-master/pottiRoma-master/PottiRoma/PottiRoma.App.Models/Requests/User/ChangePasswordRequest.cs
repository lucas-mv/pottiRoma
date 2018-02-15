using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Requests.User
{
    public class ChangePasswordRequest
    {
        public Guid UsuarioId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
