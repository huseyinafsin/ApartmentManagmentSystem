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
        public async Task<IActionResult> GetAll()
        {
            return base.BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return base.BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return base.BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BillCreateDto updateDto)
        {
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(BillCreateDto createDto)
        {
            var bill = _mapper.Map<Bill>(createDto);
            var result = await _billService.AddAsync(bill);

           return result.Success ? Ok(result) : BadRequest();
        }
    }
}
