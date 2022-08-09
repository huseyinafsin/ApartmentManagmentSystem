using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
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
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"/api/Tenant/");

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

        [HttpGet]
        public async Task<IActionResult> AddTenant( )
        {
            var tenant = new TenantForRegister();
            return View("TenantForm");
        }

        [HttpPost]
        public async Task<IActionResult>  AddTenant(TenantForRegister register)
        {
            if (ModelState.IsValid)
            {
                var strRegister = JsonConvert.SerializeObject(register);
                var data = new StringContent(strRegister, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"api/Tenant/", data);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = await httpResponseMessage.Content.ReadAsStringAsync();
                    var accessToken = JsonConvert.DeserializeObject<SuccessDataResult<TenantModelDto>>(result);
                    if (accessToken.Success)
                    {
                        
                        return RedirectToAction("Index", "Tenant");
                    }

                    return View("404Error");
                }
                return View("404Error");

            }
            return View();
        }



        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Tenant/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var tenants = JsonConvert.DeserializeObject<SuccessDataResult<TenantModelDto>>(result);
                if (tenants.Success)
                {
                    return View("TenantForm",tenants.Data);
                }

                return View("404Error");
            }
            return View("404Error");
        }      
        
        [HttpPut]
        public async Task<IActionResult> Update(TenantModelDto tenantModelDto)
        {
            var strRegister = JsonConvert.SerializeObject(tenantModelDto);
            var data = new StringContent(strRegister, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync($"api/Tenant/{tenantModelDto.Id}",data);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var accessToken = JsonConvert.DeserializeObject<SuccessResult>(result);
                if (accessToken.Success)
                {

                    return View("Index");
                }

                return View();
            }

            return View();
        }
    }
}
