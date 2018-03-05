using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Responses.Trophies;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface ITrophiesRefit
    {
        [Get("/Trophy/Get/{usuarioId}")]
        [Headers("Authorization: Bearer")]
        Task<GetThophiesByUserIdResponse> GetCurrentTrophies(string usuarioId);

        [Post("/Trophy/Insert")]
        [Headers("Authorization: Bearer")]
        Task InsertNewTrophy(InsertTrophyRequest request);
    }
}
