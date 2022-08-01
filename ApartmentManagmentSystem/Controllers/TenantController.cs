using System.Collections.Generic;
using System.Threading.Tasks;
using Bussiness.Abstracts;
using Core.Service;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tenantService.GetResidents();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _tenantService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tenantService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TenantUpdateDto updateDto)
        {
            return base.BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TenantCreateDto createDto)
        {
            return base.BadRequest();
        }

    }
}
