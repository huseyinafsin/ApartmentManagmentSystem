using System.Threading.Tasks;
using Core.Service.Abstract;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace ApartmentManagmentSystem.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class FlatTypeController : ControllerBase
    {
        private readonly IService<FlatType,int> _flatService;

        public FlatTypeController(IService<FlatType, int> flatService)
        {
            _flatService = flatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _flatService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
     }
}
