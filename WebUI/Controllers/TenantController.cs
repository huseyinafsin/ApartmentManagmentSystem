using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Dto.Concrete.Apartment.Bill;
using Dto.Concrete.Apartment.Tenant;
using Dto.Concrete.Dtos.Bill;
using Dto.Concrete.Dtos.Flat;
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
            _httpClient.BaseAddress = new Uri(Config.BaseApiUrl);
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
        public async Task<IActionResult> Add()
        {

            #region flats

            HttpResponseMessage flatResponseMessage = await _httpClient.GetAsync($"/api/Flat/GetAllWithDetails");
            var resultString = flatResponseMessage.Content.ReadAsStringAsync().Result;
            var flats = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatModelDto>>>(resultString);
            ViewBag.flats = flats.Data;

            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TenantForRegister register)
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
            #region flats

            HttpResponseMessage flatResponseMessage = await _httpClient.GetAsync($"/api/Flat/GetAllWithDetails");
            var resultString =await flatResponseMessage.Content.ReadAsStringAsync();
            var flats = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatModelDto>>>(resultString);
            ViewBag.flats = flats.Data;

            #endregion
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Tenant/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var tenants = JsonConvert.DeserializeObject<SuccessDataResult<TenantModelDto>>(result);
                if (tenants.Success)
                {
                    ViewBag.flats = flats.Data;
                    return View(tenants.Data);
                }

                return View("404Error");
            }
            return View("404Error");
        }
              

        [HttpPost]
        public async Task<IActionResult> Update(TenantModelDto tenantModelDto)
        {
            var strRegister = JsonConvert.SerializeObject(tenantModelDto);
            var data = new StringContent(strRegister, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync($"api/Tenant/{tenantModelDto.Id}", data);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var strResult = JsonConvert.DeserializeObject<SuccessResult>(result);
                if (strResult.Success)
                {

                    return RedirectToAction("Index");
                }

                return View("Details");
            }

            return View("Details");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"api/Tenant/{id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var tenants = JsonConvert.DeserializeObject<SuccessDataResult<SuccessResult>>(result);
                if (tenants.Success)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            return View();
        }
    }
}
