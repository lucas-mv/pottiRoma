using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using PottiRoma.Utils.Configurations;
using PottiRoma.Utils.Constants;
using PottiRoma.Utils.CustomExceptions;
using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Authentication
{
    public static class AuthenticationBusiness
    {
        public static void ValidateToken(AuthenticationInformationEntity authInfo)
        {
            if (authInfo != null && !String.IsNullOrEmpty(authInfo.AuthToken))
            {
                AuthenticationControlEntity authControl = AuthenticationControlRepository.Get().GetAuthControl(new Guid(authInfo.UserId), new Guid(authInfo.AuthToken));

                if (authControl == null)
                    throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.Unauthorized, Messages.INVALID_AUTHORIZATION);

                if (!authControl.KeepAlive && (DateTime.Now.Subtract(authControl.RegisterDate)).TotalHours > Settings.AuthenticationExpirationHours)
                {
                    AuthenticationControlRepository.Get().DeleteAuthControl(authControl.UserId, authControl.Token);
                    throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.Unauthorized, Messages.EXPIRED_AUTHORIZATION);
                }

            }
            else
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.Unauthorized, Messages.INVALID_AUTHORIZATION);
            }
        }

        public static void DeleteAuthentication(string userId, string token)
        {
            AuthenticationControlRepository.Get().DeleteAuthControl(new Guid(userId), new Guid(token));
        }

        public static Guid CreateAuthenticationControl(Guid userId, AuthOrigin origin)
        {
            var token = Guid.NewGuid();

            AuthenticationControlRepository.Get().InsertAuthControl(userId, token, origin, true);

            return token;
        }
    }
}
