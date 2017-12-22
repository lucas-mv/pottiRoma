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
    public class BaseController : ApiController
    {
        protected readonly IAuthenticationService _authenticationService;

        public BaseController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task ValidateToken()
        {
            var request = System.Web.HttpContext.Current.Request;
            var authInfo = new AuthenticationInformationEntity()
            {
                UserId = request.Headers.GetValues("user")[0]
            };
            if (Request.Headers.Authorization != null)
            {
                authInfo.AuthToken = Request.Headers.Authorization.Parameter;
                authInfo.AuthMethod = Request.Headers.Authorization.Scheme;
            }
            await _authenticationService.ValidateToken(authInfo);
        }
    }
}