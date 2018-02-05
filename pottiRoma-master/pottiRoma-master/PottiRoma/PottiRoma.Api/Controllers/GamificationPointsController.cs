using PottiRoma.Api.Request.PointsGamification;
using PottiRoma.Api.Response.GamificationPoints;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/GamificationPoints")]
    public class GamificationPointsController : BaseController
    {
        private readonly IGamificationPointsService _gamificationPointsService;

        public GamificationPointsController(IAuthenticationService authenticationService,
            IGamificationPointsService gamificationPointsService) : base(authenticationService)
        {
            _gamificationPointsService = gamificationPointsService;
        }

        [Route("Update")]
        [HttpPost]
        public async Task UpdateGamificationPoints(GamificationPointsRequest request)
        {
            //await ValidateToken();
            _gamificationPointsService.UpdatePoints(request.IsActive, request.AverageTicket, request.RegisterNewClients, request.SalesNumber, request.AverageItensPerSale, request.InviteFlower);
        }

        [Route("GetCurrent")]
        [HttpPost]
        public async Task<GamificationPointsResponse> GetCurrentGamificationPoints()
        {
            //await ValidateToken();

            var response = new GamificationPointsResponse();
            response.Entity = _gamificationPointsService.GetCurrentGamificationPoints();

            return response;
        }
    }
}