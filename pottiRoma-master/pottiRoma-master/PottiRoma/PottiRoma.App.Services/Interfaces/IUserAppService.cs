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

        Task SendEmail(SendEmailRequest request);
    }
}
