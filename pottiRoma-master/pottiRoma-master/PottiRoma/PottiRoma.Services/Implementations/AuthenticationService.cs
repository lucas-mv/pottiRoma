using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PottiRoma.Entities;
using PottiRoma.Business.Authentication;
using PottiRoma.Utils.Enums;

namespace PottiRoma.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        public Guid CreateAuthenticationControl(Guid userId, AuthOrigin origin)
        {
            return AuthenticationBusiness.CreateAuthenticationControl(userId, origin);
        }

        public void DeleteAuthentication(string userId, string token)
        {
            AuthenticationBusiness.DeleteAuthentication(userId, token);
        }

        public async Task ValidateToken(AuthenticationInformationEntity authInfo)
        {
            AuthenticationBusiness.ValidateToken(authInfo);
        }
    }
}
