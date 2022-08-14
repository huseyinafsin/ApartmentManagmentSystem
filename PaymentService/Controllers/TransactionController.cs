using System.Threading.Tasks;
using Bussiness.Abstracts.Payment;
using Core.Service.Abstract;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Transaction;
using Entity.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IService<Transaction, string> _transactionService;
        private readonly ICreditCardService _creditCardService;

        public TransactionController(IAccountService accountService, ICustomerService customerService, IService<Transaction, string> transactionService, ICreditCardService creditCardService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionService = transactionService;
            _creditCardService = creditCardService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Pay(TransactionCreateDto paymentCreateDto)
        {
            var customer = await
                _customerService.GetByFullname(paymentCreateDto.Firstname, paymentCreateDto.Lastname);
            if (!customer.Success)
                return BadRequest("Your Credit card is are wrong");

            var creditcard = await _accountService.GetCustomerCard(
                x => x.AccountId == customer.Data.AccountId
                     && x.Number.Equals(paymentCreateDto.Number)
                     && x.Cvv == paymentCreateDto.Cvv
                     && x.Month == paymentCreateDto.Month
                     && x.Year == paymentCreateDto.Year);


            if (creditcard.Success)
            {
                creditcard.Data.Debt -= paymentCreateDto.Amount;

                _creditCardService.Update(creditcard.Data);

                var transaction = new Transaction()
                {
                    Amount = paymentCreateDto.Amount,
                    PaymentDetails = paymentCreateDto.PaymentDetails,
                    CredditCardId = creditcard.Data.Id,
                };

                var result = await _transactionService.AddAsync(transaction);

                return Ok(result);
            }
            return BadRequest("Your Credit card info are wrong");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var results = await _transactionService.GetAllAsync();
            return results.Success ? Ok(results) : BadRequest();
        }
    }
}
