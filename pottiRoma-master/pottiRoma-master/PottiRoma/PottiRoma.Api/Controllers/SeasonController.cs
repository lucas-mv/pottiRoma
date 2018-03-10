using PottiRoma.Api.Request.Season;
using PottiRoma.Api.Response.RankingBySeason;
using PottiRoma.Api.Response.Season;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/Season")]
    public class SeasonController : BaseController
    {
        private readonly ISeasonService _seasonService;
        private readonly IUserService _userService;
        private readonly IRankingBySeasonService _rankingBySeasonService;

        public SeasonController(IAuthenticationService authenticationService, 
            ISeasonService seasonService,
            IUserService userService,
            IRankingBySeasonService rankingBySeasonService) : base(authenticationService)
        {
            _seasonService = seasonService;
            _userService = userService;
            _rankingBySeasonService = rankingBySeasonService;
        }

        [Route("GetCurrent")]
        [HttpPost]
        public async Task<SeasonResponse> GetCurrentSeason()
        {
            //await ValidateToken();

            var response = new SeasonResponse();
            response.Entity = _seasonService.GetCurrentSeason();

            return response;
        }

        [Route("Insert")]
        [HttpPost]
        public async Task InsertSeason(string name, DateTime startDate, DateTime endDate, bool isActive)
        {
            var currentSeason = await GetCurrentSeason();
            var appUsers = _userService.GetAppUsers();

            foreach (var user in appUsers)
            {
                var totalpoints = user.AverageItensPerSalePoints + user.AverageTicketPoints + user.InviteAllyFlowersPoints + user.SalesNumberPoints + user.RegisterClientsPoints;

                _rankingBySeasonService.GenerateRankingBySeason(user.Name, user.Email, currentSeason.Entity.Name, totalpoints, 
                    currentSeason.Entity.StartDate, currentSeason.Entity.EndDate, user.AverageTicketPoints,
                    user.RegisterClientsPoints, user.SalesNumberPoints, user.AverageItensPerSalePoints, user.InviteAllyFlowersPoints);

                _userService.UpdateUserPoints(user.UsuarioId, 0, 0, 0, 0, 0);
            }
             await _seasonService.InsertSeason( name, startDate, endDate, isActive);
        }

        [Route("GetRankingBySeason")]
        [HttpPost]
        public async Task<RankingBySeasonResponse> GetRankingBySeason()
        {
            await ValidateToken();
            return new RankingBySeasonResponse()
            {
                RankingBySeason = _seasonService.GetRankingBySeason()
            };
        }
    }
}