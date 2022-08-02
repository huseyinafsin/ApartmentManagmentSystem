using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dto.Concrete.Dtos.Tenant;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class FlatController : Controller
    {
        private readonly HttpClient _httpClient;

        public FlatController( )
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.Constans.ApiUrl);
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> FlatDetails(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Tenant/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var residents = JsonConvert.DeserializeObject<TenantModelDto>(result);
                return View(residents);
            }
            return View();
        }


    }
}
