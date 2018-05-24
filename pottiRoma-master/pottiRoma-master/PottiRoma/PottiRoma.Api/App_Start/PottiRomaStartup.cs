using Microsoft.Owin;
using Owin;
using PottiRoma.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

[assembly: OwinStartup("PottiStartupConfiguration", typeof(PottiRoma.Api.App_Start.PottiRomaStartup))]
namespace PottiRoma.Api.App_Start
{
    public class PottiRomaStartup
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