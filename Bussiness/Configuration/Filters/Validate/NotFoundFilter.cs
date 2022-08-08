using System.Linq;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoContentResult = Core.Utilities.Results.NoContentResult;

namespace Bussiness.Configuration.Filters.Validate
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T,int> _service;

        public NotFoundFilter(IService<T,int> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);
            if (anyEntity.Success)
            {
                await next.Invoke();
            }

            context.Result = new NotFoundObjectResult(CustomReponseDto<NoContentResult>.Fail(404, $"{typeof(T).Name}({id}) not found"));
        }
    }
}
