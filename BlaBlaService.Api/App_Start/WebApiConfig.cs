using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using BlaBlaService.Api.App_Start;
using Swashbuckle.Application;

namespace BlaBlaService.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());

            // Provide only JSON Formatter
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableSwagger(f => f.SingleApiVersion("v1", "BlaBlaSevice")).EnableSwaggerUi();
        }
    }
}
