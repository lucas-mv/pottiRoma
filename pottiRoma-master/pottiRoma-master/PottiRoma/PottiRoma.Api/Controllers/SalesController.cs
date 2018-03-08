using PottiRoma.Api.Request.Sales;
using PottiRoma.Api.Request.User;
using PottiRoma.Api.Response.Sales;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            await ValidateToken();
            return new GetSalesByUserIdResponse()
            {
                Sales = _salesService.GetSalesByUserId(new Guid(usuarioId))
            };
        }

        [Route("New")]
        [HttpPost]
        public async Task InsertNewSale(InsertNewSaleRequest request)
        {
            await ValidateToken();
            _salesService.InsertNewSale(request.UsuarioId, request.ClienteId, request.UserName, request.ClientName, request.SaleDate, request.SaleValue, request.SalePaidValue, request.NumberSoldPieces, request.Description);
        }

        [Route("UpdateSale")]
        [HttpPost]
        public async Task UpdateSale(string vendaId, float saleValue, float salePaidValue, int numberSoldPieces, string description)
        {
            await ValidateToken();
            _salesService.UpdateSale(new Guid(vendaId), saleValue, salePaidValue, numberSoldPieces, description);
        }

        [Route("GetAllSales")]
        [HttpPost]
        public async Task<List<SaleEntity>> GetAllSales()
        {
            await ValidateToken();
            return _salesService.GetAllSales();
        }

        [Route("Report")]
        [HttpGet]
        public async Task<HttpResponseMessage> GenerateSalesReport()
        {
            await ValidateToken();
            var fileName = "RelatorioVendas_"+DateTime.Now.ToShortDateString().Replace("/", "-")+".xlsx";
            var reportData = _salesService.GenerateSalesReport();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(reportData)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            return response;
        }

        [Route("GetUserSalePointsForChallenge")]
        [HttpGet]
        public async Task<int> GetUserSalePointsForChallenge(string usuarioId)
        {
            await ValidateToken();
            return _salesService.GetUserSalePointsForChallenge(new Guid(usuarioId));
        }
    }
}