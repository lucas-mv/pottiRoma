using PottiRoma.App.Models.Requests.User;
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

        public async Task<LoginReponse> Login(LoginRequest request)
        {
            return await UserApiRepository.Get().Login(request);
        }

        public async Task Logout(string userId)
        {
            await UserApiRepository.Get().Logout(userId);
        }

        public async Task SendEmail(SendEmailRequest request)
        {
            await UserApiRepository.Get().SendEmail(request);
        }

        public async Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            await UserApiRepository.Get().UpdateUser(usuarioId, email, primaryTelephone, secundaryTelephone, cep);
        }

        public async Task UpdateUserPoints(UpdateUserPointsRequest request)
        {
            await UserApiRepository.Get().UpdateUserPoints(request);
        }
    }
}
