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
        public static string FormatMoney(decimal parameter)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;
            string Retorno = parameter.ToString("N", nfi);
            Retorno = string.Concat("R$ ", Retorno);
            return Retorno;
        }

        public static string FormatDate(DateTime Date)
        {
            string StringDate = Date.ToString();
            string FormattedDate = Convert.ToDateTime(StringDate).ToString("yyyy-MM-dd");
            return FormattedDate;
        }
    }
}
