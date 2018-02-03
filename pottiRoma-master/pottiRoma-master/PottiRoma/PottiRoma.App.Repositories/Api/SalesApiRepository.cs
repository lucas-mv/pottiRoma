using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Responses.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class SalesApiRepository
    {
        #region Instance

        private static SalesApiRepository _instance;
        public static SalesApiRepository Get()
        {
            if (_instance == null)
                _instance = new SalesApiRepository();

            return _instance;
        }

        #endregion

        public async Task<GetSalesByUserIdResponse> GetSalesByUserId(string usuarioId)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<ISalesRefit>().GetSalesByUserId(usuarioId)
              );
            return response;
        }

        public async Task InsertNewSale(InsertNewSaleRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<ISalesRefit>().InsertNewSale(request)
              );
        }
    }
}
