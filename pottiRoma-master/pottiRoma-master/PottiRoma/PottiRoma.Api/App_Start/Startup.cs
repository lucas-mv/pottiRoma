using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Web.Http.Filters;
using PottiRoma.Utils.CustomExceptions;
using System.Net.Http;

[assembly: OwinStartup(typeof(PottiRoma.Api.App_Start.Startup))]
namespace PottiRoma.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SimpleInjectorInitializer.Initialize();

            GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilter());

            app.UseWebApi(GlobalConfiguration.Configuration);

            DateTime now = new DateTime();
            now = DateTime.Now;

            var jsonNow = Newtonsoft.Json.JsonConvert.SerializeObject(now);
        }
    }

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ExceptionWithHttpStatus customException = null;

            if (context.Exception is ExceptionWithHttpStatus)
            {
                customException = context.Exception as ExceptionWithHttpStatus;
            }
            else if (context.Exception.InnerException is ExceptionWithHttpStatus)
            {
                customException = context.Exception.InnerException as ExceptionWithHttpStatus;
            }

            if (customException != null)
            {
                context.Response = new HttpResponseMessage(customException.GetStatusCode());
                context.Response.Content = new StringContent(customException.Message);
            }
            else
            {
                context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                context.Response.Content = new StringContent(String.Format("{0} / {1}", context.Exception.Message,
                    context.Exception.InnerException != null ? context.Exception.InnerException.Message : String.Empty));
            }
        }
    }
}