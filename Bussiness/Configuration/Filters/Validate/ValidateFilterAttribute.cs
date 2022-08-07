using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bussiness.Configuration.Filters.Validate
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new BadRequestObjectResult(new ErrorDataResult<List<string>>{Data =errors});

            }
        }

    }
}
