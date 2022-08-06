using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Bussiness.Configuration.Log
{
    public class LogFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var msLogger = context.HttpContext.RequestServices.GetService<MongoDbLogger>();
            var data = context.ActionArguments.Values;
            var logStr = System.Text.Json.JsonSerializer.Serialize(data);

            msLogger.LoggerManager.Information(logStr);

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("İşlem tamamlandı");
        }
    }
}