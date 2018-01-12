using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Responses.User
{
    public class LoginReponse
    {
        public PottiRoma.App.Models.Models.User User { get; set; }
        public Guid Token { get; set; }
    }
}
