using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class SaleEntity
    {
        public Guid VendaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ClienteId { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }
        public DateTime SaleDate { get; set; }
        public float SaleValue { get; set; }
        public float SalePaidValue { get; set; }
        public int NumberSoldPieces { get; set; }
    }
}
