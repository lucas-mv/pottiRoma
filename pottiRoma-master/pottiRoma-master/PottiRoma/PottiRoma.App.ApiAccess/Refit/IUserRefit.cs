﻿using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.User;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface IUserRefit
    {
        [Post("/User/Profile/Password")]
        [Headers("Authorization: Bearer")]
        Task ChangePassword(ChangePasswordRequest request);

        [Post("/User/Login")]
        [Headers("Authorization: Bearer")]
        Task<LoginReponse> Login(LoginRequest request);

        [Get("/User/Logout/{id}")]
        [Headers("Authorization: Bearer")]
        Task Logout([AliasAs("id")]string userId);

        [Post("/User/SendEmail")]
        [Headers("Authorization: Bearer")]
        Task SendEmail(SendEmailRequest request);

        [Post("/User/Profile/Update")]
        [Headers("Authorization: Bearer")]
        Task UpdateUserPoints(UpdateUserPointsRequest request);

        [Post("/User/GetAppUsers")]
        [Headers("Authorization: Bearer")]
        Task<GetAppUsersResponse> GetAppUsers();

        [Post("/User/UpdateUser")]
        [Headers("Authorization: Bearer")]
        Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep);
    }
}
