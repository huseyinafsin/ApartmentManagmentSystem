using System.Threading.Tasks;
using Core.Service;
using Entity.Concrete;
using Entity.Concrete.Dtos.Bill;
using Entity.Concrete.Dtos.Flat;
using Entity.Concrete.Dtos.Resident;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        IService<Flat> _flatService;

        public FlatController(IService<Flat> flatService)
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var result = await _flatService.GetByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return base.BadRequest();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(FlatUpdateDto updateDto)
        //{
        //    return base.BadRequest();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(FlatCreateDto createDto)
        //{
        //    return base.BadRequest();
        //}
    }
}
