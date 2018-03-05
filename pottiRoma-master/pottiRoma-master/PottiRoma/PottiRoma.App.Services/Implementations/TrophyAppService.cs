using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Responses.Trophies;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class TrophyAppService : ITrophyAppService
    {
        public async Task<GetThophiesByUserIdResponse> GetCurrentTrophies(string usuarioId)
        {
            return await TrophiesApiRepository.Get().GetCurrentTrophies(usuarioId);
        }

        public async Task InsertNewTrophy(InsertTrophyRequest request)
        {
            await TrophiesApiRepository.Get().InsertNewTrophy(request);
        }
    }
}
