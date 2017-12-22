using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils
{
    public static class ExtensionMethods
    {
        public static string PadronizeTelephone(this string telephone)
        {
            return telephone.Replace("(", String.Empty)
                            .Replace(")", String.Empty)
                            .Replace("+", String.Empty)
                            .Replace("-", String.Empty)
                            .Replace(" ", String.Empty);
        }
    }
}
