
using System.Threading.Tasks;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Bussiness.Configuration.Interceptors
{
    public class TransactionInterceptor : ActionFilterAttribute
    {
        private ApartmentContext _apartmentContext;

        public TransactionInterceptor(ApartmentContext apartmentContext)
        {
            _apartmentContext = apartmentContext;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ApartmentContext apartmentContext = _apartmentContext == null ? context.HttpContext.RequestServices.GetService<ApartmentContext>() : _apartmentContext;
            using (var transaction = apartmentContext.Database.BeginTransaction())
            {
                // do something before
                ActionExecutedContext resultContext = await next();
                //do something after
                if (resultContext.Exception != null) await transaction.RollbackAsync();
                else await transaction.CommitAsync();
            }
        }
    }
}
