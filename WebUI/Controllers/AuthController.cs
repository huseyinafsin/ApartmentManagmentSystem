using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Config.BaseApiUrl);

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLogin forLogin)
        {

            var strLogin = JsonConvert.SerializeObject(forLogin);
            var data = new StringContent(strLogin, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"api/Auth/Login", data);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var accessToken = JsonConvert.DeserializeObject<SuccessDataResult<AccessToken>>(result);
                if (accessToken.Success)
                {
                    var accessTokenString = JsonConvert.SerializeObject(accessToken.Data.Token);
                   HttpContext.SetCookie("token", accessTokenString,accessToken.Data.Expiration);
                    return RedirectToAction("Index", "Home");
                }

                return View("404Error");
            }
            return View("404Error");
        }



    }
}
