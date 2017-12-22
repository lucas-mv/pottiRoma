using PottiRoma.Entities;
using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task ValidateToken(AuthenticationInformationEntity authInfo);
        void DeleteAuthentication(string userId, string token);
        Guid CreateAuthenticationControl(Guid userId, AuthOrigin origin);
    }
}
