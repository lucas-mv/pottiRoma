using PottiRoma.App.Models.Requests.Challenges;
using PottiRoma.App.Models.Responses.Challenges;
using PottiRoma.App.Models.Responses.Sales;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class ChallengesAppService : IChallengesAppService
    {
        public async Task<GetCurrentChallengesResponse> GetCurrentChallenges(string temporadaId)
        {
            return await ChallengesApiRepository.Get().GetCurrentChallenges(temporadaId);
        }

        public async Task InsertNewChallenge(InsertChallengeRequest request)
        {
            await ChallengesApiRepository.Get().InsertNewChallenge(request);
        }
    }
}
