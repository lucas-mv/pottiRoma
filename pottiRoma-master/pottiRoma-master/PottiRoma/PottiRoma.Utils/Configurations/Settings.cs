using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils.Configurations
{
    public class Settings
    {
        public static int AuthenticationExpirationHours
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["AuthenticationExpirationHours"]);
            }
        }
    }
}
