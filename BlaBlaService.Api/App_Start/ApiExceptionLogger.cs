using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace BlaBlaService.Api.App_Start
{
    internal class ApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;
            var controllerContext = context.ExceptionContext.ControllerContext;
            if (controllerContext != null)
            {
                Trace.TraceError("***** UNHANDLED API CONTROLLER EXCEPTION *****\r\n{0}", ex.ToString());
            }
            else
            {
                Trace.TraceError("***** UNHANDLED API EXCEPTION *****\r\n{0}", ex.ToString());
            }
        }
    }
}