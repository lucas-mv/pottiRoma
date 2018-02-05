using PottiRoma.App.Models.Responses.GamificationPoints;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class GamificationPointsAppService : IGamificationPointsAppService
    {
        public async Task<GetGamificationPointsResponse> GetCurrentGamificationPoints()
        {
            return await GamificationPointsApiRepository.Get().GetCurrentGamificationPoints();
        }
    }
}
