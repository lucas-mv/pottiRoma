using PottiRoma.App.Models.Responses.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface ISeasonAppService
    {
        Task<SeasonResponse> CurrentSeason();
    }
}
