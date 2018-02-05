using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Requests.User
{
    public class UpdateUserPointsRequest
    {
        public Guid UsuarioId { get; set; }
        public int AverageTicketPoints { get; set; }
        public int RegisterClientsPoints { get; set; }
        public int SalesNumberPoints { get; set; }
        public int AverageItensPerSalePoints { get; set; }
        public int InviteAllyFlowersPoints { get; set; }
    }
}
