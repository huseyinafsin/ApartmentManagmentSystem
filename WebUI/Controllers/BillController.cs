using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Bill;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class BillController : Controller
    {

        private readonly HttpClient _httpClient;
        public BillController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.Constans.ApiUrl);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserBills(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/Bill/GetByUserId/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                var userbills = JsonConvert.DeserializeObject<SuccessDataResult<List<BillCreateDto>>>(result);
                if (userbills.Success)
                {
                    return View(userbills.Data);
                }

                return View("404Error");
            }
            return View("404Error");
        }

    }
}
