using System;
using System.Threading.Tasks;
using Core.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebUI
{
    public class CustomAuthecnticationHandler : AuthenticationHandler<JwtBearerHandler>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Context.GetCookie("token");
            Response.Headers["Authorization"] = token;
        }
    }
}
