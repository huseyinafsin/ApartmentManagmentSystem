using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Utilities.Results;
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
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"/api/Tenant/GetAll");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var residents = JsonConvert.DeserializeObject<SuccessDataResult<List<TenantModelDto>>>(result);

                if (residents.Success)
                {
                    return View(residents.Data);
                }

                return View("404Error");
            }
            return View("404Error");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Tenant/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result =await httpResponseMessage.Content.ReadAsStringAsync();
                var tenants = JsonConvert.DeserializeObject<SuccessDataResult<TenantModelDto>>(result);
                if (tenants.Success)
                {
                    return View(tenants.Data);
                }

                return View("404Error");
            }
            return View("404Error");
        }
    }
}
