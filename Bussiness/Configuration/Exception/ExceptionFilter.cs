using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Configuration.Log;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Configuration.Exception
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
  
            var mongoLogger = (context.HttpContext.RequestServices.GetService(typeof(MongoDbLogger))) as MongoDbLogger;

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
