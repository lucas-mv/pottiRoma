using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Responses;
using PottiRoma.App.Models.Responses.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class SeasonApiRepository
    {
        #region Instance

        private static SeasonApiRepository _instance;
        public static SeasonApiRepository Get()
        {
            if (_instance == null)
                _instance = new SeasonApiRepository();

            return _instance;
        }

        #endregion

        public async Task<SeasonResponse> CurrentSeason()
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<ISeasonRefit>().CurrentSeason()
              );
            return response;
        }
    }
}
