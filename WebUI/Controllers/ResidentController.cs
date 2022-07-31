using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ResidentController : Controller
    {
        private readonly HttpClient _httpClient;

        public ResidentController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.Constans.ApiUrl);
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Resident/GetAll");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var residents = JsonConvert.DeserializeObject<List<ResidentModelDto>>(result);
                return View(residents);
            }
            return View();
        }
    }
}
