using PottiRoma.Api.Helpers;
using PottiRoma.Api.Request.Email;
using PottiRoma.Api.Request.User;
using PottiRoma.Api.Response.Email;
using PottiRoma.Api.Response.User;
using PottiRoma.Services.Interfaces;
using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PottiRoma.Api.Controllers
{
    [RoutePrefix("api/v1/User")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IAuthenticationService authenticationService, IUserService userService) : base(authenticationService)
        {
            _userService = userService;
        }

        [Route("Login")]
        [HttpPost]
        public LoginResponse LoginUser(LoginUserRequest request)
        {
            var response = new LoginResponse();
            response.User = _userService.Authenticate(request.Email, request.Password);
            response.Token = _authenticationService.CreateAuthenticationControl(response.User.UserId, request.Origin);
            return response;
        }

        [Route("Register")]
        [HttpPost]
        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            return new RegisterUserResponse()
            {
                User = _userService.RegisterUser(request.Email, request.Password, request.Name, request.PrimaryTelephone, request.SecondaryTelephone, request.Cpf, request.UserType)
            };
        }

        //[HttpPost]
        //[Route("EnviarEmail")]
        //public async Task<SendEmailResponse> EnviarEmail(SendEmailRequest request)
        //{
        //    //Email.Enviar(request.Assunto, request.CorpoEmail, request.Destinatarios, request.Cc, null, , emailNomeFrom.Item2, _logoPath);
        //    //return ResponseResult(string.Empty);
        //}
    }
}