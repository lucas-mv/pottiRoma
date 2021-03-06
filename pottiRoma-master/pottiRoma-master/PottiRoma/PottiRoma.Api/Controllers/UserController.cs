﻿using PottiRoma.Api.Helpers;
using PottiRoma.Api.Request.Email;
using PottiRoma.Api.Request.User;
using PottiRoma.Api.Response.Email;
using PottiRoma.Api.Response.User;
using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using PottiRoma.Services.Interfaces;
using PottiRoma.Utils.CustomExceptions;
using PottiRoma.Utils.Enums;
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
            response.User = _userService.Authenticate(request.Email, request.Password, request.Origin);
            response.Token = _authenticationService.CreateAuthenticationControl(response.User.UsuarioId, request.Origin);
            return response;
        }

        [Route("Get/Salesperson")]
        [HttpGet]
        public async Task<List<SalespersonEntity>> GetAllSalespeople()
        {
            await ValidateToken();
            return _userService.GetAllSalespeople();
        }

        [Route("Report")]
        [HttpGet]
        public async Task<HttpResponseMessage> GenerateSalespeopleReport()
        {
            await ValidateToken();
            var fileName = "RelatorioRevendedoras_" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xlsx";
            var reportData = _userService.GenerateSalespeopleReport();

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
            //await ValidateToken();
            var checkUserEmailRegistered = _userService.GetUserByEmail(request.Email);
            if (checkUserEmailRegistered != null)
            {
                throw new Exception("Email de usuário já cadastrado");
            }
            return new RegisterUserResponse()
            {
                User = _userService.RegisterUser(request.Email, request.Password, request.Name, request.PrimaryTelephone, request.SecundaryTelephone, request.Cpf, request.UserType,request.Cep,request.AverageTicketPoints,request.RegisterClientsPoints,request.SalesNumberPoints,request.AverageItensPerSalePoints,request.InviteAllyFlowersPoints,request.TemporadaId,request.MotherFlowerId, request.IsActive, request.Birthday)
            };
        }

        [Route("Profile/Password")]
        [HttpPost]
        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await ValidateToken();
            _userService.ChangePassword(request.UsuarioId, request.OldPassword, request.NewPassword);
        }

        [Route("ResetPasswordByEmail")]
        [HttpPost]
        public async Task ResetPasswordByEmail(ResetPasswordByEmailRequest request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, "Email não encontrado!");
            user = _userService.ResetPassword(user.UsuarioId);
            EmailResetPassword.Enviar(user.Email, user.Name, user.Password);
        }

        [Route("Profile/Password/Reset/{usuarioId}")]
        [HttpGet]
        public async Task ResetPassword(string usuarioId)
        {
            var user = _userService.ResetPassword(new Guid(usuarioId));  
            EmailResetPassword.Enviar(user.Email, user.Name, user.Password);
        }

        [HttpPost]
        [Route("SendEmail")]
        public async void SendEmail(string emailInvited,string nameInvited, string nameUser, string cpf, string telephone, string cep, string emailInviter)
        {
            EmailInvite.Enviar(emailInvited, nameInvited, nameUser, cpf, telephone, cep, emailInviter);
        }

        [HttpPost]
        [Route("SendBirthdayEmail")]
        public async void SendBirthdayEmail(string emailInvited, string userName)
        {
            EmailBirthday.Enviar(emailInvited, userName);
        }

        [Route("Profile/Update")]
        [HttpPost]
        public async Task UpdateClientInfo(UpdateUserPointsRequest request)
        {
            await ValidateToken();
            _userService.UpdateUserPoints(request.UsuarioId ,request.AverageTicketPoints, request.RegisterClientsPoints, request.SalesNumberPoints, request.AverageItensPerSalePoints, request.InviteAllyFlowersPoints);
        }

        [Route("GetAppUsers")]
        [HttpPost]
        public async Task<GetAppUsersResponse> GetAppUsers()
        {
            await ValidateToken();
            return new GetAppUsersResponse()
            {
                Users = _userService.GetAppUsers()
            };
        }

        [Route("GetAllAppUsers")]
        [HttpPost]
        public async Task<GetAppUsersResponse> GetAllAppUsers()
        {
            await ValidateToken();
            return new GetAppUsersResponse()
            {
                Users = _userService.GetAllAppUsers()
            };
        }

        [Route("UpdateStatus")]
        [HttpPost]
        public async Task UpdateUserStatus(UpdateUserStatusRequest request)
        {
            await ValidateToken();
            _userService.UpdateUserStatus(request.UserId, request.IsActive);
        }

        [Route("UpdateUser")]
        [HttpPost]
        public async Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            await ValidateToken();
            _userService.UpdateUser(new Guid(usuarioId), email, primaryTelephone, secundaryTelephone, cep);
        }

        [Route("Profile/GetUserByEmail")]
        [HttpPost]
        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        [Route("GetUserInvitePointsForChallenge/{usuarioId}")]
        [HttpGet]
        public async Task<int> GetUserInvitePointsForChallenge(string usuarioId)
        {
            await ValidateToken();
            return _userService.GetUserInvitePointsForChallenge(new Guid(usuarioId));
        }
    }
}