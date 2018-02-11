using PottiRoma.App.Models.Responses.GamificationPoints;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface IGamificationPointsRefit
    {
        [Post("/GamificationPoints/GetCurrent")]
        [Headers("Authorization: Bearer")]
        Task<GetGamificationPointsResponse> GetCurrentGamificationPoints();
    }
}
