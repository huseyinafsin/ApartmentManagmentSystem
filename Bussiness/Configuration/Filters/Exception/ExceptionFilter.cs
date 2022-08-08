using System.Net;
using Bussiness.Configuration.Filters.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bussiness.Configuration.Filters.Exception
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            var mongoLogger = (context.HttpContext.RequestServices.GetService(typeof(MongoDbLogger))) as MongoDbLogger;
            mongoLogger.LogType = LogType.Error;

            var jsonResult = new JsonResult(
                new
                {
                    error = context.Exception.Message,
                    innerException = context.Exception.InnerException,
                    statusCode = HttpStatusCode.InternalServerError
                }

            );
            mongoLogger.LoggerManager.Error(jsonResult.Value.ToString());

            context.Result = jsonResult;

            base.OnException(context);
        }
    }
}
