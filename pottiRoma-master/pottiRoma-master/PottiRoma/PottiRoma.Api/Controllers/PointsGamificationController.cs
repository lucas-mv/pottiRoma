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
    [RoutePrefix("api/v1/PointsGamification")]
    public class PointsGamificationController : BaseController
    {
        private readonly IGamificationPointsService _gamificationPointsService;

        public PointsGamificationController(IAuthenticationService authenticationService,
            IGamificationPointsService gamificationPointsService) : base(authenticationService)
        {
            _gamificationPointsService = gamificationPointsService;
        }

        [Route("Update")]
        [HttpPost]
        public async Task UpdateGamificationPoints(GamificationPointsRequest request)
        {
            //await ValidateToken();
            _gamificationPointsService.UpdatePoints(request.PontosGamificacaoId, request.AverageTicket, request.RegisterNewClients, request.SalesNumber, request.AverageItensPerSale, request.InviteFlower);
        }

        [Route("Get")]
        [HttpPost]
        public async Task<GamificationPointsByIdResponse> GetGamificationPointsById(string gamificationPointsId)
        {
            //await ValidateToken();
            return new GamificationPointsByIdResponse()
            {
                GamificationPoints = _gamificationPointsService.GetGamificationPointsById(new Guid(gamificationPointsId))
            };
        }
    }
}