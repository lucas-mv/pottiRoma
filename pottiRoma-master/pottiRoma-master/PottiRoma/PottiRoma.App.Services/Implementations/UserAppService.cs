﻿using PottiRoma.App.Models.Requests.User;
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

        public async Task<LoginResponse> Login(LoginUserRequest request)
        {
            return await UserApiRepository.Get().Login(request);
        }
    }
}
