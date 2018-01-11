using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static PottiRoma.App.Utils.Constants;

namespace PottiRoma.App.ApiAccess
{
    public class PottiRomaApiAccess
    {
        #region PottiRoma client instance

        private static HttpClient _pottiRomaClient;
        public static HttpClient PottiRomaClient
        {
            get
            {
                if (_pottiRomaClient == null)
                    _pottiRomaClient = new HttpClient(new AuthenticatedHttpClientHandler())
                    {
                        BaseAddress = Global.ApiBaseUrls[Global.SELECTED_ENVIROMENT]
                    };
                return _pottiRomaClient;
            }
        }

        #endregion

        public static Api GetPottiRomaApi<Api>()
        {
            return RestService.For<Api>(PottiRomaClient);
        }
    }
}
