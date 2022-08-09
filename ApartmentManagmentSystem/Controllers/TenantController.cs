using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Service;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace ApartmentManagmentSystem.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public TenantController(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAll()
        {
            var result = await _tenantService.GetAllWithDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _tenantService.GetWithDetails(id);
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
        public async Task<IActionResult> Update(int id,TenantModelDto tenantModelDto)
        {
            var tenant = _mapper.Map<Tenant>(tenantModelDto);
            await _tenantService.UpdateAsync(tenant);
            var result = await _tenantService.GetWithDetails(tenantModelDto.Id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TenantForRegister tenantForRegister)
        {
            var result =await _tenantService.AddTenant(tenantForRegister);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
