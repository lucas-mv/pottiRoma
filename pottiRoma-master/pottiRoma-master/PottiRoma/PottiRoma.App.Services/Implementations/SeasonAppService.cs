using PottiRoma.App.Models.Responses;
using PottiRoma.App.Models.Responses.Seasons;
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
