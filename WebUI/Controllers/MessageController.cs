using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Core.Constants;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Message;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly HttpClient _httpClient;

        public MessageController( )
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Config.BaseApiUrl);

        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage userListRequest = await _httpClient.GetAsync($"/api/Users");

            if (userListRequest.IsSuccessStatusCode)
            {
               var result= JsonConvert.DeserializeObject<SuccessDataResult<List<UserModel>>>(userListRequest.Content.ReadAsStringAsync().Result);

               if (result.Success)
               {
                   ViewData["UserList"] = result.Data;
               }
            }

            var content = new GetUserMessagesBetween()
            {
                FromUserId = 2,
                ToUserId = 1,
            };
            HttpResponseMessage httpResponseMessage =await _httpClient.PostAsJsonAsync($"/api/Messages/GetUserMessagesBetween",content);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result =await httpResponseMessage.Content.ReadAsStringAsync();
                var residents = JsonConvert.DeserializeObject<SuccessDataResult<List<MessageModel>>>(result);
                return View(residents);
            }
            return View();
        }
    }
}
