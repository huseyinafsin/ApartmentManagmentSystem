using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dto.Concrete.Dtos.Tenant;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TenantController : Controller
    {
        private readonly HttpClient _httpClient;

        public TenantController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.Constans.ApiUrl);
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Tenant/GetAll");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var residents = JsonConvert.DeserializeObject<List<TenantModelDto>>(result);
                return View(residents);
            }
            return View();
        }
    }
}
