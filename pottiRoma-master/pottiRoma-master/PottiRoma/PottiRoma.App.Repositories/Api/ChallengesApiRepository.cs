using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Requests.Challenges;
using PottiRoma.App.Models.Responses.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class ChallengesApiRepository
    {
        #region Instance

        private static ChallengesApiRepository _instance;
        public static ChallengesApiRepository Get()
        {
            if (_instance == null)
                _instance = new ChallengesApiRepository();

            return _instance;
        }

        #endregion

        public async Task<GetCurrentChallengesResponse> GetCurrentChallenges(string temporadaId)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IChallengesRefit>().GetCurrentChallenges(temporadaId)
              );
            return response;
        }

        public async Task InsertNewChallenge(InsertChallengeRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IChallengesRefit>().InsertNewChallenge(request)
              );
        }
    }
}
