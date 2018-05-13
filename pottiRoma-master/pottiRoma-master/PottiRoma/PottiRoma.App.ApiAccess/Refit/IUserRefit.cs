using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.Trophies;
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
        Task SendEmail(string emailInvited, string nameInvited, string nameUser, string cpf, string telephone, string cep, string emailInviter);

        [Post("/User/SendBirthdayEmail")]
        [Headers("Authorization: Bearer")]
        Task SendBirthdayEmail(string emailInvited, string userName);

        [Post("/User/Profile/Update")]
        [Headers("Authorization: Bearer")]
        Task UpdateUserPoints(UpdateUserPointsRequest request);

        [Post("/User/GetAllAppUsers")]
        [Headers("Authorization: Bearer")]
        Task<GetAppUsersResponse> GetAllAppUsers();

        [Post("/User/GetAppUsers")]
        [Headers("Authorization: Bearer")]
        Task<GetAppUsersResponse> GetAppUsers();

        [Post("/User/UpdateUser")]
        [Headers("Authorization: Bearer")]
        Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep);

        [Post("/User/Profile/GetUserByEmail")]
        [Headers("Authorization: Bearer")]
        Task<User> GetUserByEmail(string email);

        [Get("/User/Profile/Password/Reset/{usuarioId}")]
        [Headers("Authorization: Bearer")]
        Task ResetPassword(string usuarioId);

        [Get("/User/GetUserInvitePointsForChallenge/{usuarioId}")]
        [Headers("Authorization: Bearer")]
        Task<int> GetUserInvitePointsForChallenge(string usuarioId);
    }
}
