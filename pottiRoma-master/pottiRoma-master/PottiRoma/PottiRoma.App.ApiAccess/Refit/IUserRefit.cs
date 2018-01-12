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
        [Post("/api/v1/User/Profile/Password")]
        [Headers("Authorization: Bearer")]
        Task ChangePassword(ChangePasswordRequest request);

        [Post("/api/v1/User/Login")]
        [Headers("Authorization: Bearer")]
        Task<LoginResponse> Login(LoginUserRequest request);
    }
}
