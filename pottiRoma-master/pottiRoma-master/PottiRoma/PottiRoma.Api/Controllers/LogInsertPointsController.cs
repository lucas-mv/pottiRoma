using PottiRoma.Api.Request.InsertNewLogRequest;
using PottiRoma.Services.Interfaces;
using PottiRoma.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Services.Description;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/LogInsertPoints")]
    public class LogInsertPointsController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogInsertPointsService _logInsertPointsService;

        public LogInsertPointsController(IAuthenticationService authenticationService, 
            IUserService userService,
            ILogInsertPointsService logInsertPointsService) : base(authenticationService)
        {
            _userService = userService;
            _logInsertPointsService = logInsertPointsService;
        }

        [Route("New")]
        [HttpPost]
        public async Task InsertNewLog(LogInsertPointsRequest request)
        {
            await ValidateToken();
            try
            {
                var user = _userService.GetUserByEmail(request.UserEmail);

                _logInsertPointsService.InsertNewLog(user.UsuarioId, request.UserEmail, request.AverageTicket, request.RegisterNewClients, request.SalesNumber, request.AverageItensPerSale, request.InviteFlower, request.Description);

                user.AverageTicketPoints += request.AverageTicket;
                user.AverageItensPerSalePoints += request.AverageItensPerSale;
                user.RegisterClientsPoints += request.RegisterNewClients;
                user.SalesNumberPoints += request.SalesNumber;
                user.InviteAllyFlowersPoints += request.InviteFlower;
                _userService.UpdateUserPoints(user.UsuarioId, user.AverageTicketPoints, user.RegisterClientsPoints, user.SalesNumberPoints, user.AverageItensPerSalePoints, user.InviteAllyFlowersPoints);
            }
            catch
            {
                throw new Exception(Messages.INVALID_USER);
            }
        }
    }
}