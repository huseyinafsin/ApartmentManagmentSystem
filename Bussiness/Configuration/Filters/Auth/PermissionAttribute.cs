using Core.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Configuration.Filters.Auth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(OperationClaim permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }

    }
}
