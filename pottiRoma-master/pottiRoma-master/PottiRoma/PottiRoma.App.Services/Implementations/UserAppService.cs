using PottiRoma.App.Models.Models;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.Trophies;
using PottiRoma.App.Models.Responses.User;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class UserAppService : IUserAppService
    {
        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await UserApiRepository.Get().ChangePassword(request);
        }

        public async Task<GetAppUsersResponse> GetAppUsers()
        {
            return await UserApiRepository.Get().GetAppUsers();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await UserApiRepository.Get().GetUserByEmail(email);
        }

        public async Task<LoginReponse> Login(LoginRequest request)
        {
            return await UserApiRepository.Get().Login(request);
        }

        public async Task Logout(string usuarioId)
        {
            await UserApiRepository.Get().Logout(usuarioId);
        }

        public async Task ResetPassword(string email)
        {
            await UserApiRepository.Get().ResetPassword(email);
        }

        public async Task SendEmail(string emailInvited, string nameInvited, string nameUser, string cpf, string telephone, string cep)
        {
            await UserApiRepository.Get().SendEmail(emailInvited, nameInvited, nameUser, cpf, telephone, cep);
        }

        public async Task SendBirthdayEmail(string emailInvited, string nameUser)
        {
            await UserApiRepository.Get().SendBirthdayEmail(emailInvited, nameUser);
        }

        public async Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            await UserApiRepository.Get().UpdateUser(usuarioId, email, primaryTelephone, secundaryTelephone, cep);
        }

        public async Task UpdateUserPoints(UpdateUserPointsRequest request)
        {
            await UserApiRepository.Get().UpdateUserPoints(request);
        }

        public async Task<int> GetUserInvitePointsForChallenge(string usuarioId)
        {
            return await UserApiRepository.Get().GetUserInvitePointsForChallenge(usuarioId);
        }
    }
}
