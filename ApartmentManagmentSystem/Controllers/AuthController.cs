using System;
using System.Security.Claims;
using Bussiness.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Dto.Concrete.User;
using Microsoft.AspNetCore.Authorization;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ManagerRegister(ManagerForRegister managerForRegister)
        {
            var result =await _authService.ManagerRegister(managerForRegister);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Tenant")]
        public async Task<IActionResult> ChangePassword(string password)
        {
            var userId = Convert.ToInt16(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var result = await _authService.ChangePassword(userId, password);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserForLogin userForLogin)
        {
            var result =await _authService.Login(userForLogin);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
