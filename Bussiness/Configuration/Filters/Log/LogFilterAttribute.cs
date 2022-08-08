using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Bussiness.Configuration.Filters.Log
{
    public class LogFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var mongoLogger = context.HttpContext.RequestServices.GetService<MongoDbLogger>();
            mongoLogger.LogType = LogType.Informational;

            var data = context.ActionArguments.Values;
            var logStr = System.Text.Json.JsonSerializer.Serialize(data);

            mongoLogger.LoggerManager.Information(logStr);

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("İşlem tamamlandı");
        }
    }
}