using PottiRoma.App.Models.Responses.Season;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class SeasonAppService : ISeasonAppService
    {
        public async Task<SeasonResponse> CurrentSeason()
        {
            return await SeasonApiRepository.Get().CurrentSeason();
        }
    }
}
