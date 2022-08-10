using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Dto.Concrete.Apartment.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessages(int id)
        {
            var result = await _messageService.GetUserMessages(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserMessagesBetween(GetUserMessagesBetween between)
        {
            var result = await _messageService.GetUserMessagesBetween(between);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(MessageCreateDto createDto)
        {
            var result = await _messageService.CreateMessage(createDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageCreateDto messageCreateDto)
        {
            var result = await _messageService.SendMessage(messageCreateDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
