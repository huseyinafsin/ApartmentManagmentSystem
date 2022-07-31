using System.Collections.Generic;
using System.Threading.Tasks;
using Bussiness.Abstracts;
using Core.Service;
using Entity.Concrete;
using Entity.Concrete.Dtos.Resident;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _residentService.GetResidents();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return NotFound();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var result =await _residentService.GetByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _residentService.RemoveAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound();
        //}       
        
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(ResidentUpdateDto updateDto)
        //{
        //    return base.BadRequest();
        //} 

        //[HttpPost]
        //public async Task<IActionResult> Post(ResidentCreateDto createDto)
        //{
        //    return base.BadRequest();
        //} 
        
    }
}
