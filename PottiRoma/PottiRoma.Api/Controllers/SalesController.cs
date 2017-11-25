using PottiRoma.Api.Request.Sales;
using PottiRoma.Api.Response.Sales;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/Sales")]
    public class SalesController : BaseController
    {
        readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        [Route("Person/New")]
        public async Task<NewSalesPersonResponse> NewSalesPerson(NewSalesPersonRequest request)
        {
            _salesService.NewSalesPerson();
            return new NewSalesPersonResponse();
        }
    }
}