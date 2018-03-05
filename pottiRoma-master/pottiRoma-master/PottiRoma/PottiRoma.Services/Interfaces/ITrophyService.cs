﻿using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface ITrophyService
    {
        void InsertNewTrophy(Guid usuarioId, Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal);

        List<TrophyEntity> GetTrophies(Guid userId);
    }
}
