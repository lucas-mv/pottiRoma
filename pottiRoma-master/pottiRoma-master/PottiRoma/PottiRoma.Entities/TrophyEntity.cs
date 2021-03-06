﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class TrophyEntity
    {
        public Guid DesafioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TemporadaId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Parameter { get; set; }
        public int Goal { get; set; }
        public int Prize { get; set; }
    }
}
