using ModernHttpClient;
using PottiRoma.App.Utils;
using PottiRoma.App.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess
{
    public class AuthenticatedHttpClientHandler : NativeMessageHandler
    {
        public AuthenticatedHttpClientHandler()
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            HttpResponseMessage response = null;

            if (auth != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, Settings.AccessToken);
                request.Headers.Add(Constants.HeaderUser, Settings.UserId);
            }

            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (await ValidateResponse(response))
                return response;
            else
                return null;
        }

        private async Task<bool> ValidateResponse(HttpResponseMessage response)
        {
            if (response == null)
                return false;

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                throw new ErrorException("Oops! Não foi possível conectar à internet. Pode checar sua conexão?");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ValidationException(await response.Content.ReadAsStringAsync());
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new AuthorizationException();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
            {
                throw new ErrorException("Oops! Não foi possível conectar à internet. Pode checar sua conexão?");
            }

            return true;
        }
    }
}
