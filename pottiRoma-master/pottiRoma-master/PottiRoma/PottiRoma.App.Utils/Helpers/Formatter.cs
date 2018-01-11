using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.Helpers
{
    public static class Formatter
    {
        public static string FormatDRE(decimal parameter)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;
            string Retorno = parameter.ToString("N", nfi);
            Retorno = string.Concat("R$ ", Retorno);
            return Retorno;
        }
    }
}
