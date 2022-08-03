using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Repository.Abstract;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastDal weatherForecastDal;

        public WeatherForecastController(IWeatherForecastDal weatherForecastDal)
        {
            this.weatherForecastDal = weatherForecastDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await weatherForecastDal.GetAll();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = weatherForecastDal.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] WeatherForecast data)
        {var result = weatherForecastDal.AddAsync(data).Result;
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] WeatherForecast data)
        { 
           await weatherForecastDal.UpdateAsync(data,x=>x.Id==id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            var result =await weatherForecastDal.GetByIdAsync(id);
            weatherForecastDal.DeleteAsync(result);
            
            return NoContent();
        }
    }
}
