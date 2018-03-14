using PottiRoma.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PottiRoma.Business.General
{
    public static class EmailValidator
    {
        public static void IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, "Endereço de email inválido!");

            var valid = false;
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                valid = Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, "Endereço de email inválido!");
            }

            if(!valid)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, "Endereço de email inválido!");
        }

        private static string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            domainName = idn.GetAscii(domainName);

            return match.Groups[1].Value + domainName;
        }
    }
}
