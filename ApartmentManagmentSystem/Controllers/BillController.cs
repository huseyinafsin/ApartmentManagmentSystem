using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Dto.Concrete.Apartment.Bill;
using Dto.Concrete.Dtos.Bill;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {

        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillController(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            var result =await _billService.GetAllWithDetails();
            return result.Success ? Ok(result) : BadRequest();
        }    
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTenantBills(int id)
        {
            var result =await _billService.GetTenantBills(id);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithDetails(int id)
        {
            var result =await _billService.GetWithDetails(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _billService.RemoveAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Bill bill)
        {
            var result =  _billService.Update(bill);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post( MultiBillCreateDto multiBillCreateDto )
        {
            var result = await _billService.CreateBill(multiBillCreateDto);

           return result.Success ? Ok(result) : BadRequest();
        }
    }
}
