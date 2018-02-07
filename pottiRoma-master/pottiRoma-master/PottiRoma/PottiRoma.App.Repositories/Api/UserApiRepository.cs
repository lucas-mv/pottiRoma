using Polly;
using PottiRoma.App.ApiAccess;
using PottiRoma.App.ApiAccess.Refit;
using PottiRoma.App.Models.Requests.User;
using PottiRoma.App.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Api
{
    public class UserApiRepository
    {
        #region Instance

        private static UserApiRepository _instance;
        public static UserApiRepository Get()
        {
            if (_instance == null)
                _instance = new UserApiRepository();

            return _instance;
        }

        #endregion

        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().ChangePassword(request)
              );
        }

        public async Task SendEmail(SendEmailRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().SendEmail(request)
              );
        }

        public async Task<LoginReponse> Login(LoginRequest request)
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().Login(request)
              );
            return response;
        }

        public async Task Logout(string userId)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().Logout(userId)
              );
        }

        public async Task UpdateUserPoints(UpdateUserPointsRequest request)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().UpdateUserPoints(request)
              );
        }

        public async Task<GetAppUsersResponse> GetAppUsers()
        {
            var response = await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().GetAppUsers()
              );
            return response;
        }

        public async Task UpdateUser(string usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            await Policy
             .Handle<WebException>()
             .WaitAndRetryAsync
             (
               retryCount: 5,
               sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
             )
             .ExecuteAsync(async () =>
                   await PottiRomaApiAccess.GetPottiRomaApi<IUserRefit>().UpdateUser(usuarioId, email, primaryTelephone, secundaryTelephone, cep)
             );
        }
    }
}
