using System.Threading.Tasks;
using Core.Service.Abstract;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillTypeController : ControllerBase
    {
        private readonly IService<BillType,int> _billTypeService;

        public BillTypeController(IService<BillType, int> billTypeService)
        {
            _billTypeService = billTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _billTypeService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BillType billType)
        {
            var result = await _billTypeService.AddAsync(billType);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, BillType billType)
        {
            var result = _billTypeService.Update(billType);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
