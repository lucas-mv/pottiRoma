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

        public SalesController(ISalesService salesService, IAuthenticationService authenticationService) : base(authenticationService)
        {
            _salesService = salesService;
        }

        [Route("Get/{usuarioId}")]
        [HttpGet]
        public async Task<GetSalesByUserIdResponse> GetSalesByUserId(string usuarioId)
        {
            //await ValidateToken();
            return new GetSalesByUserIdResponse()
            {
                Sales = _salesService.GetSalesByUserId(new Guid(usuarioId))
            };
        }

        [Route("New")]
        [HttpPost]
        public async Task InsertNewSale(InsertNewSaleRequest request)
        {
            //await ValidateToken();
            _salesService.InsertNewSale(request.UsuarioId, request.ClienteId, request.UserName, request.ClientName, request.SaleDate, request.SaleValue, request.SalePaidValue, request.NumberSoldPieces);
        }
    }
}