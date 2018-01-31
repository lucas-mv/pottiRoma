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
        public async Task<LoginResponse> LoginUser(LoginUserRequest request)
        {
            var response = new LoginResponse();
            response.User = _userService.Authenticate(request.Email, request.Password);
            response.Token = _authenticationService.CreateAuthenticationControl(response.User.UsuarioId, request.Origin);
            return response;
        }

        [Route("Logout/{id}")]
        [HttpGet]
        public async Task LogoutUser(string id)
        {
            _userService.Logout(id);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            return new RegisterUserResponse()
            {
                User = _userService.RegisterUser(request.Email, request.Password, request.Name, request.PrimaryTelephone, request.SecondaryTelephone, request.Cpf, request.UserType, request.Birthday, request.FlowerId)
            };
        }

        [Route("Profile/Password")]
        [HttpPost]
        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await ValidateToken();
            _userService.ChangePassword(request.UserId, request.OldPassword, request.NewPassword);
        }

        [Route("Profile/Password/Reset/Request/{userId}")]
        [HttpGet]
        public async Task RequestPasswordReset(string userId)
        {
            var user = _userService.GetUserById(new Guid(userId));
            var corpoEmail = "Para redefinir uma nova senha para o app da Potti Roma, por favor clique no link abaixo:\n\n" +
                "pottiroma.azurewebsites.net/api/v1/User/Profile/Password/Reset/" + userId;
            var destinatario = new Dictionary<string, string>();
            destinatario.Add(user.Email, user.Name);
            Email.Enviar("Potti Roma - Confirme requisição de nova senha", corpoEmail, destinatario);
        }

        [Route("Profile/Password/Reset/{userId}")]
        [HttpGet]
        public async Task ResetPassword(string userId)
        {
            var user = _userService.ResetPassword(new Guid(userId));
            var corpoEmail = "A sua senha do app da Potti Roma foi redefinida com sucesso para a senha temporária indicada abaixo:\n\n" + user.Password;
            var destinatario = new Dictionary<string, string>();
            destinatario.Add(user.Email, user.Name);
            Email.Enviar("Potti Roma - Nova senha", corpoEmail, destinatario);
        }

        [HttpPost]
        [Route("SendEmail")]
        public async Task<SendEmailResponse> SendEmail(SendEmailRequest request)
        {
            await ValidateToken();
            var user = _userService.GetUserById(request.UserId);
            Email.Enviar(request.Assunto, request.CorpoEmail, request.Destinatarios, request.Cc, null, user.Email, user.Name, null);
            return new SendEmailResponse()
            {
                IsSuccess = true
            };
        }
    }
}