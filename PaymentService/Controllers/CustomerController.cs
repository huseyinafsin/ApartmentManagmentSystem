using System.Threading.Tasks;
using Bussiness.Abstracts.Payment;
using Core.Repository;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Customer;
using Entity.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(IRepository<Customer> customerRepository, ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }       
        
        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateDto customerCreate)
        {
            var result = await _customerService.CreateCustomer(customerCreate);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
