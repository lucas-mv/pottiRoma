using PottiRoma.Api.Request.Trophies;
using PottiRoma.Api.Response.Trophies;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/Trophy")]
    public class TrophiesController : BaseController
    {
        private readonly ITrophyService _trophyService;
        private readonly ISeasonService _seasonService;

        public TrophiesController(IAuthenticationService authenticationService,
            ITrophyService trophyService,
            ISeasonService seasonService) : base(authenticationService)
        {
            _trophyService = trophyService;
            _seasonService = seasonService;
        }

        [Route("Insert")]
        [HttpPost]
        public async Task InsertNewTrophy(InsertTrophyRequest request)
        {
            await ValidateToken();
            var temporadaId = _seasonService.GetCurrentSeason();
            _trophyService.InsertNewTrophy(request.UsuarioId, temporadaId.TemporadaId, request.Name, request.StartDate, request.EndDate, request.Parameter, request.Goal);
        }

        [Route("Get/{usuarioId}")]
        [HttpGet]
        public async Task<GetTrophiesResponse> GetTrophies(string usuarioId)
        {
            //await ValidateToken();
            return new GetTrophiesResponse()
            {
                Trophies = _trophyService.GetTrophies(new Guid(usuarioId))
            };
        }
    }
}