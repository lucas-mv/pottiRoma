using PottiRoma.App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Responses.Trophies
{
    public class GetThophiesByUserIdResponse
    {
        public List<Trophy> Trophies { get; set; }
    }
}
