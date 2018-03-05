using PottiRoma.Api.Request.Clients;
using PottiRoma.Api.Response.Clients;
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
    [RoutePrefix("api/v1/Clients")]
    public class ClientsController : BaseController
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IAuthenticationService authenticationService,
            IClientsService clientsService) : base(authenticationService)
        {
            _clientsService = clientsService;
        }

        [Route("Register")]
        [HttpPost]
        public async Task RegisterClient(RegisterClientRequest request)
        {
            //await ValidateToken();
            _clientsService.RegisterClient(request.UsuarioId, request.Name, request.Telephone, request.Email, request.Cep, request.Birthdate);
        }

        [Route("Update")]
        [HttpPost]
        public async Task UpdateClientInfo(UpdateClientRequest request)
        {
            await ValidateToken();
            _clientsService.UpdateClientInfo(request.ClienteId, request.Name, request.Telephone, request.Email, request.Cep, request.Birthdate);
        }

        [Route("Get/{usuarioId}")]
        [HttpGet]
        public async Task<GetClientsByUserIdResponse> GetClientsByUserId(string usuarioId)
        {
            await ValidateToken();
            return new GetClientsByUserIdResponse()
            {
                Clients = _clientsService.GetClientsByUserId(new Guid(usuarioId))
            }; 
        }

        [Route("Get")]
        [HttpGet]
        public async Task<GetClientsByUserIdResponse> GetClientsAllClients()
        {
            await ValidateToken();
            return new GetClientsByUserIdResponse()
            {
                Clients = _clientsService.GetAllClients()
            };
        }

        [Route("Remove")]
        [HttpGet]
        public async Task RemoveCliente(string clienteId)
        {
            await ValidateToken();
            _clientsService.RemoveCliente(new Guid(clienteId));
        }

        [Route("Report")]
        [HttpGet]
        public async Task<HttpResponseMessage> GenerateClientsReport()
        {
            await ValidateToken();
            var fileName = "RelatorioClientes_" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xlsx";
            var reportData = _clientsService.GenerateClientsReport();

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
    }
}