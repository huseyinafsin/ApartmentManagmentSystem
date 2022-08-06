using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Configuration.Auth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(OperationClaim permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }

    }
}
