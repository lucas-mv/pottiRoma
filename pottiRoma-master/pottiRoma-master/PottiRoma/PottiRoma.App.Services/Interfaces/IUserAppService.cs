using PottiRoma.App.Models.Requests.User;
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
        Task Logout(string userId);
        Task SendEmail(SendEmailRequest request);
        Task UpdateUserPoints(UpdateUserPointsRequest request);
        Task<GetAppUsersResponse> GetAppUsers();
        Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep);
    }
}
