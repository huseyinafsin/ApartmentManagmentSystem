using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class ContextCookie
    {
        public static void SetCookie(this HttpContext httpContext, string key, string value, DateTime expireTime)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = expireTime;


            httpContext.Response.Cookies.Append(key, value, option);
        }

        public static void RemoveCookie(this HttpContext httpContext, string key)
        {
            httpContext.Response.Cookies.Delete(key);
        }
    }
}
