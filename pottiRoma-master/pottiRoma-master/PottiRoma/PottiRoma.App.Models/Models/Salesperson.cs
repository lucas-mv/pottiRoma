using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Salesperson
    {
        public Guid SalespersonId { get; set; }
        public Guid UserId { get; set; }
        public Guid FlowerId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
