using PottiRoma.App.Models.Responses.Season;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface ISeasonRefit
    {
        [Post("/Season/GetCurrent")]
        [Headers("Authorization: Bearer")]
        Task<SeasonResponse> CurrentSeason();
    }
}
