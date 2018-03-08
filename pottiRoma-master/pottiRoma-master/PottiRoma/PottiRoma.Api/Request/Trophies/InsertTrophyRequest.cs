using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.Trophies
{
    public class InsertTrophyRequest
    {
        public Guid DesafioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TemporadaId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Parameter { get; set; }
        public int Goal { get; set; }
    }
}