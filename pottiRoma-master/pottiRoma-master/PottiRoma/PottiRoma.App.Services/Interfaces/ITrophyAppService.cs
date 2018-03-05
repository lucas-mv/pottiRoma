using PottiRoma.App.Models.Requests.Trophies;
using PottiRoma.App.Models.Responses.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface ITrophyAppService
    {
        Task<GetThophiesByUserIdResponse> GetCurrentTrophies(string usuarioId);
        Task InsertNewTrophy(InsertTrophyRequest request);
    }
}
