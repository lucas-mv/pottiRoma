using PottiRoma.App.Models.Requests.Challenges;
using PottiRoma.App.Models.Responses.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface IChallengesAppService
    {
        Task<GetCurrentChallengesResponse> GetCurrentChallenges(string temporadaId);
        Task InsertNewChallenge(InsertChallengeRequest request);
    }
}
