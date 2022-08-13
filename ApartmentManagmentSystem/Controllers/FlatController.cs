using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Bussiness.Configuration.Filters.Log;
using Core.Service;
using Dto.Concrete.Apartment.Flat;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
       private readonly IFlatService _flatService;
       private readonly IMapper _mapper;

        public FlatController(IFlatService flatService, IMapper mapper)
        {
            _flatService = flatService;
            _mapper = mapper;
        }

        [LogFilter]
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
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetWithDetails(int id)
        {
            var result = await _flatService.GetWithDetails(id);
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
            var result =await _flatService.RemoveAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FlatModelDto flatModelDto)
        {
            var flat = _mapper.Map<Flat>(flatModelDto);
            var result = _flatService.Update(flat);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [LogFilter]
        public async Task<IActionResult> Post(FlatCreateDto createDto)
        {
            var result = await _flatService.Create(createDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
