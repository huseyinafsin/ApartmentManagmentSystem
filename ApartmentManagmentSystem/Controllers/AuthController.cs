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
    }
}
