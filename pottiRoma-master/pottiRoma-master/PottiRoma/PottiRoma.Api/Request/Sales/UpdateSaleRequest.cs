using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.Sales
{
    public class UpdateSaleRequest
    {
        public float SaleValue { get; set; }
        public float SalePaidValue { get; set; }
        public int NumberSoldPieces { get; set; }
        public string Description { get; set; }
    }
}