using PottiRoma.App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Responses.Clients
{
    public class GetClientsBySalespersonIdResponse
    {
        public List<Cliente> Clients { get; set; }
    }
}
