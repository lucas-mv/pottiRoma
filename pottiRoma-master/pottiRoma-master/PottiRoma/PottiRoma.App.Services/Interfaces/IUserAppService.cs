using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.Trophies;
using PottiRoma.App.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface IUserAppService
    {
        Task ChangePassword(ChangePasswordRequest request);
        Task<LoginReponse> Login(LoginRequest request);
        Task Logout(string usuarioId);
        Task SendEmail(string emailInvited, string nameInvited, string nameUser, string cpf, string telephone, string cep);
        Task SendBirthdayEmail(string emailInvited, string nameUser);
        Task UpdateUserPoints(UpdateUserPointsRequest request);
        Task<GetAppUsersResponse> GetAppUsers();
        Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep);
        Task<User> GetUserByEmail(string email);
        Task ResetPassword(string email);
        Task<int> GetUserInvitePointsForChallenge(string usuarioId);
    }
}
