using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.Sales
{
    public class GetSalesByUserIdResponse
    {
        public List<SaleEntity> Sales { get; set; }
    }
}