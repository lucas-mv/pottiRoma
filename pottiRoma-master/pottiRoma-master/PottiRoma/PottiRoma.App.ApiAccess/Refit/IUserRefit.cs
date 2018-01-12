using PottiRoma.App.Models.Requests.User;
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

        //[Post("/User/SendEmail")]
        //[Headers("Authorization: Bearer")]
        //Task SendEmail(SendEmailRequest request);
    }
}
