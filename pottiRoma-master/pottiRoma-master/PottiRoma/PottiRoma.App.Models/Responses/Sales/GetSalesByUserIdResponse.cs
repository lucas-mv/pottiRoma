using PottiRoma.App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Responses.Sales
{
    public class GetSalesByUserIdResponse
    {
        public List<Sale> Sales { get; set; }
    }
}
