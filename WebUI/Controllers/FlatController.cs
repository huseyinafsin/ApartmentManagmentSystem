﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Constants;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Flat;
using Dto.Concrete.Dtos.Flat;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class FlatController : Controller
    {
        private readonly HttpClient _httpClient;

        public FlatController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Config.BaseApiUrl);
        }


        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"/api/Flat/GetAllWithDetails");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var flats = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatModelDto>>>(result);

                if (flats.Success)
                {
                    return View(flats.Data);
                }

                return View("404Error");
            }

            return View("404Error");

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var flat = new FlatCreateDto();
            HttpResponseMessage flatTypeResponseMessage = await _httpClient.GetAsync($"/api/FlatType/");
            if (flatTypeResponseMessage.IsSuccessStatusCode)
            {
                var flatTyperesult = await flatTypeResponseMessage.Content.ReadAsStringAsync();
                var flatTypes = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatType>>>(flatTyperesult).Data;
                ViewBag.flatTypes = flatTypes;
            }


            return View(flat);
        }


        [HttpPost]
        public async Task<IActionResult> Add(FlatCreateDto createDto)
        {
            if (ModelState.IsValid)
            {
                var strRegister = JsonConvert.SerializeObject(createDto);
                var data = new StringContent(strRegister, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"api/Flat/", data);


                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = await httpResponseMessage.Content.ReadAsStringAsync();

                    var flat = JsonConvert.DeserializeObject<SuccessDataResult<FlatModelDto>>(result);

                    if (flat.Success)
                    {
                        return RedirectToAction("Index", "Flat");
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
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"/api/Flat/GetWithDetails/{id}");
            HttpResponseMessage flatTypeResponseMessage = await _httpClient.GetAsync($"/api/FlatType/");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var flatTyperesult = await flatTypeResponseMessage.Content.ReadAsStringAsync();
                var flat = JsonConvert.DeserializeObject<SuccessDataResult<FlatModelDto>>(result);
                var flatTypes = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatType>>>(flatTyperesult).Data;
                if (flat.Success)
                {
                    ViewData["flatTypes"] = flatTypes;
                    return View(flat.Data);
                }

                return View("404Error");
            }

            return View("404Error");
        }





        [HttpPost]
        public async Task<IActionResult> Update(FlatModelDto flatModelDto)
        {
       
            #region flatTypes
            HttpResponseMessage flatTypeResponseMessage = await _httpClient.GetAsync($"/api/FlatType/");
            var flatTyperesult = await flatTypeResponseMessage.Content.ReadAsStringAsync();
            var flatTypes = JsonConvert.DeserializeObject<SuccessDataResult<List<FlatType>>>(flatTyperesult).Data;
            #endregion

            flatModelDto.FlatType = flatTypes.FirstOrDefault(x=>x.Id== flatModelDto.Id);
            var strRegister = JsonConvert.SerializeObject(flatModelDto);
            var data = new StringContent(strRegister, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync($"api/Flat/{flatModelDto.Id}", data);



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
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"api/Flat/{id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var tenants = JsonConvert.DeserializeObject<SuccessDataResult<FlatModelDto>>(result);
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
