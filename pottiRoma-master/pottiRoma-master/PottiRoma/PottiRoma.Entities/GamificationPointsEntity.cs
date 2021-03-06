﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class GamificationPointsEntity
    {
        public Guid PontosGamificacaoId { get; set; }
        public int AverageTicket { get; set; }
        public int RegisterNewClients { get; set; }
        public int SalesNumber { get; set; }
        public int AverageItensPerSale { get; set; }
        public int InviteFlower { get; set; }
        public bool IsActive { get; set; }
    }
}
