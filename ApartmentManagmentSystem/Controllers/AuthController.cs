using Bussiness.Abstracts;
using Entity.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ResidentRegister(ResidentForRegister residentForRegister)
        {
            var result =await _authService.ResidentRegister(residentForRegister);
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
