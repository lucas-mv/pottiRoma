using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;

[assembly: OwinStartup(typeof(PottiRoma.Api.App_Start.Startup))]
namespace PottiRoma.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            SimpleInjectorInitializer.Initialize();

            app.UseWebApi(GlobalConfiguration.Configuration);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["AccessTokenExpireInMinutes"])),
                Provider = new ADAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}