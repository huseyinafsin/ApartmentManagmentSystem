using System;
using System.Threading.Tasks;
using Bussiness.Abstracts.Apartment;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Payment;
using Dto.Concrete.Payment.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PaymentCreateDto paymentCreateDto)
        {
            var result =await _paymentService.Pay(paymentCreateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
