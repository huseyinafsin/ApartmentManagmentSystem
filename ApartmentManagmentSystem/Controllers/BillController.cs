using System.Threading.Tasks;
using Entity.Concrete.Dtos.Bill;
using Entity.Concrete.Dtos.Resident;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return base.BadRequest();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Get()
        //{
        //    return base.BadRequest();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return base.BadRequest();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(BillCreateDto updateDto)
        //{
        //    return base.BadRequest();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(BillCreateDto createDto)
        //{
        //    return base.BadRequest();
        //}
    }
}
