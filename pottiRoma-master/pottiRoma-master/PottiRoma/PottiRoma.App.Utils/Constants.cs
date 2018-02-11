using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils
{
    public class Constants
    {
        public const string HeaderUser = "user";
        public const string AKAVACHE_APP_NAME = "PottiRoma";

        public class CacheKeys
        {
            public const string USER_KEY = "User";
            public const string ACCESS_TOKEN = "AccessToken";
            public const string SEASON_KEY = "Season";
            public const string CLIENTS = "Clients";
            public const string POINTS = "GamificationPoints";
            public const string FIRST_ACCESS = "FirstAccess";
            public const string BIRTHDAYS = "Birthdays";
        }

        public class Global
        {
            public const string SELECTED_ENVIROMENT = Enviroments.Development;

            public static class Enviroments
            {
                public const string Development = "dev";
                public const string Homologation = "hom";
                public const string Production = "prd";
            }

            public static readonly Dictionary<string, Uri> ApiBaseUrls = new Dictionary<string, Uri>()
            {
                {
                    Enviroments.Production,
                    new Uri("https://pottiroma.azurewebsites.net/api/v1")
                },
                {
                    Enviroments.Development,
                    new Uri("https://pottiroma.azurewebsites.net/api/v1")
                },
                {
                    Enviroments.Homologation,
                    new Uri("https://pottiroma.azurewebsites.net/api/v1")
                }
            };
        }
    }
}
