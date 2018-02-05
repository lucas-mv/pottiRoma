using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Responses.GamificationPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class GamificationPointsApiRepository
    {
        #region Instance

        private static GamificationPointsApiRepository _instance;
        public static GamificationPointsApiRepository Get()
        {
            if (_instance == null)
                _instance = new GamificationPointsApiRepository();

            return _instance;
        }

        #endregion

        public async Task<GetGamificationPointsResponse> GetCurrentGamificationPoints()
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IGamificationPointsRefit>().GetCurrentGamificationPoints()
              );
            return response;
        }
    }
}
