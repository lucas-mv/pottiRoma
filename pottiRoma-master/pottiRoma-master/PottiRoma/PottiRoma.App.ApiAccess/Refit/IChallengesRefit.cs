using PottiRoma.App.Models.Requests.Challenges;
using PottiRoma.App.Models.Responses.Challenges;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface IChallengesRefit
    {
        [Get("/Challenge/Get/{temporadaId}")]
        [Headers("Authorization: Bearer")]
        Task<GetCurrentChallengesResponse> GetCurrentChallenges(string temporadaId);

        [Post("/Challenge/Insert")]
        [Headers("Authorization: Bearer")]
        Task InsertNewChallenge(InsertChallengeRequest request);
    }
}
