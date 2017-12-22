using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.CustomExceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
            : base(String.Empty)
        { }

        public AuthorizationException(string message)
            : base(message)
        { }
    }
}
