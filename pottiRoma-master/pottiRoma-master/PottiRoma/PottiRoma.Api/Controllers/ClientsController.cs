using PottiRoma.Api.Request.Clients;
using PottiRoma.Api.Response.Clients;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await ValidateToken();
            _clientsService.RegisterClient(request.SalespersonId, request.Name, request.Telephone, request.Email, request.Address, request.Birthdate);
        }

        [Route("Get/{salespersonid}")]
        [HttpGet]
        public async Task<GetClientsBySalespersonIdResponse> GetClientsBySalespersonId(string salespersonid)
        {
            await ValidateToken();
            return new GetClientsBySalespersonIdResponse()
            {
                Clients = _clientsService.GetClientsBySalespersonId(new Guid(salespersonid))
            }; 
        }
    }
}