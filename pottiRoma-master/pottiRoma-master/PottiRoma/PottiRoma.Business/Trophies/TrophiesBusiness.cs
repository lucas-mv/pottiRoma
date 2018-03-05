using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Trophies
{
    public class TrophiesBusiness
    {
        public static void InsertNewTrophy(Guid usuarioId,Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal)
        {
            var newTrophy = new TrophyEntity()
            {
                UsuarioId = usuarioId,
                TemporadaId = temporadaId,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Parameter = parameter,
                Goal = goal,
            };

            TrophiesRepository.Get().InsertNewTrophy(newTrophy);
        }

        public static List<TrophyEntity> GetTrophies(Guid usuarioId)
        {
            return TrophiesRepository.Get().GetTrophies(usuarioId);
        }
    }
}
