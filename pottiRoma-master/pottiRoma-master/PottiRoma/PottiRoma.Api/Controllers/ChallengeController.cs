using PottiRoma.Api.Request.Challenges;
using PottiRoma.Api.Response.Challenges;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/Challenge")]
    public class ChallengeController : BaseController
    {
        private readonly IChallengesService _challengesService;
        private readonly ISeasonService _seasonService;

        public ChallengeController(IAuthenticationService authenticationService,
            IChallengesService challengesService,
            ISeasonService seasonService) : base(authenticationService)
        {
            _challengesService = challengesService;
            _seasonService = seasonService;
        }

        [Route("Insert")]
        [HttpPost]
        public async Task InsertNewChallenge(InsertChallengeRequest request)
        {
            await ValidateToken();
            var temporadaId = _seasonService.GetCurrentSeason();
            _challengesService.InsertNewChallenge(temporadaId.TemporadaId, request.Name, request.StartDate, request.EndDate, request.Parameter, request.Goal, request.Prize, request.Description);
        }

        [Route("Get/{temporadaId}")]
        [HttpGet]
        public async Task<GetCurrentChallengesResponse> GetCurrentChallenges(string temporadaId)
        {
            //await ValidateToken();
            return new GetCurrentChallengesResponse()
            {
                Challenges = _challengesService.GetCurrentChallenges(new Guid(temporadaId))
            };
        }
    }
}