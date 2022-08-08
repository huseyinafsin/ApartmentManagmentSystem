using System.Linq;
using Core.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Bussiness.Configuration.Filters.Auth
{
    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly OperationClaim _permission;
        public PermissionFilter(OperationClaim permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {


            var cacheClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Roles");
            if (cacheClaim == null)
                context.Result = new BadRequestResult();


            var cacheManager = context.HttpContext.RequestServices.GetService<IDistributedCache>();

            var strCachePermissions = cacheManager.GetString(cacheClaim.Value);

            if (string.IsNullOrWhiteSpace(strCachePermissions))
            {
                context.Result = new ForbidResult("Bu metoda yetkiniz yok");
            }
            else
            {
                var cachePermissionList =
                    System.Text.Json.JsonSerializer.Deserialize<OperationClaim[]>(strCachePermissions);

                if (!cachePermissionList.Any(x => x == _permission))
                    context.Result = new ForbidResult("Bu metoda yetkiniz yok");
            }
        }
    }
}