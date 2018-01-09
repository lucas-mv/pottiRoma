using PottiRoma.Api.Request.Clients;
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
            _clientsService.RegisterClient(request.SalespersonId, request.Name, request.Cpf, request.Telephone, request.Email, request.Address);
        }

        [Route("Get/{salespersonid}")]
        [HttpGet]
        public async Task RegisterClient(string salespersonid)
        {
            await ValidateToken();
            _clientsService.GetClientsBySalespersonId(new Guid(salespersonid));
        }
    }
}