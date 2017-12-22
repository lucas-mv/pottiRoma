using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities.Internal
{
    public class PasswordCrypto
    {
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
