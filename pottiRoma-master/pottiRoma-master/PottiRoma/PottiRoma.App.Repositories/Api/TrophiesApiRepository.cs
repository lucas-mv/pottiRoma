using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Responses.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class TrophiesApiRepository
    {
        #region Instance

        private static TrophiesApiRepository _instance;
        public static TrophiesApiRepository Get()
        {
            if (_instance == null)
                _instance = new TrophiesApiRepository();

            return _instance;
        }

        #endregion

        public async Task<GetThophiesByUserIdResponse> GetCurrentTrophies(string usuarioId)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<ITrophiesRefit>().GetCurrentTrophies(usuarioId)
              );
            return response;
        }

        public async Task InsertNewTrophy(InsertTrophyRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<ITrophiesRefit>().InsertNewTrophy(request)
              );
        }
    }
}
