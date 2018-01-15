using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Responses.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class ClientsApiRepository
    {
        #region Instance

        private static ClientsApiRepository _instance;
        public static ClientsApiRepository Get()
        {
            if (_instance == null)
                _instance = new ClientsApiRepository();

            return _instance;
        }

        #endregion

        public async Task<GetClientsBySalespersonIdResponse> GetClientsBySalespersonId(string salespersonId)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IClientsRefit>().GetClientsBySalespersonId(salespersonId)
              );
            return response;
        }

        public async Task RegisterClient(RegisterClientRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IClientsRefit>().RegisterClient(request)
              );
        }
    }
}
