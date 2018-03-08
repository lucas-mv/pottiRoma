using PottiRoma.Business.Trophies;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class TrophyService : ITrophyService
    {
        public List<TrophyEntity> GetTrophies(Guid userId)
        {
            return TrophiesBusiness.GetTrophies(userId);
        }

        public void InsertNewTrophy(Guid desafioId,Guid usuarioId, Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal)
        {
            TrophiesBusiness.InsertNewTrophy(desafioId, usuarioId, temporadaId, name, startDate, endDate, parameter, goal);
        }
    }
}
