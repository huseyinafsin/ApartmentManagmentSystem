using System.Threading.Tasks;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Service;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flatService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }     
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            var result = await _flatService.GetAllWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _flatService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return base.BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(FlatUpdateDto updateDto)
        {
            return base.BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(FlatCreateDto createDto)
        {
            return base.BadRequest();
        }
    }
}
