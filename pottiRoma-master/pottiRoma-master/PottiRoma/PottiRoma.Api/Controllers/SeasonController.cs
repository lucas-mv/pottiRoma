using PottiRoma.Api.Request.Season;
using PottiRoma.Api.Response.Season;
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

        public SeasonController(IAuthenticationService authenticationService, ISeasonService seasonService) : base(authenticationService)
        {
            _seasonService = seasonService;
        }

        [Route("GetCurrent")]
        [HttpPost]
        public async Task<SeasonResponse> CurrentSeason()
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
             await _seasonService.InsertSeason( name, startDate, endDate, isActive);
        }
    }
}