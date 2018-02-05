using PottiRoma.App.Models.Responses.GamificationPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface IGamificationPointsAppService
    {
        Task<GetGamificationPointsResponse> GetCurrentGamificationPoints();
    }
}
