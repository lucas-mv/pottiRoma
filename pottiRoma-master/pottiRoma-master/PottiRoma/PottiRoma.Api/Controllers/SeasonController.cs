using PottiRoma.Api.Request.Season;
using PottiRoma.Api.Response.RankingBySeason;
using PottiRoma.Api.Response.Season;
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
        public async Task InsertSeason(InsertSeasonRequest request)
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
             await _seasonService.InsertSeason( request.Name, request.StartDate, request.EndDate, request.IsActive);
        }

        [Route("RankingBySeason")]
        [HttpGet]
        public async Task<RankingBySeasonResponse> GetRankingBySeason()
        {
            await ValidateToken();
            return new RankingBySeasonResponse()
            {
                RankingBySeason = _seasonService.GetRankingBySeason()
            };
        }

        [Route("Report")]
        [HttpGet]
        public async Task<HttpResponseMessage> GenerateRankingBySeasonReport()
        {
            await ValidateToken();
            var fileName = "RelatorioRankingPorTemporada_" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xlsx";
            var reportData = _rankingBySeasonService.GenerateRankingBySeasonReport();

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