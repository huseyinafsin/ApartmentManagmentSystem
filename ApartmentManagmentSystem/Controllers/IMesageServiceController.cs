using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Dto.Concrete.Apartment.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMesageServiceController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public IMesageServiceController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageCreateDto messageCreateDto)
        {
            var result =await _messageService.SendMessage(messageCreateDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
