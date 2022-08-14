using System.Threading.Tasks;
using Bussiness.Abstracts.Payment;
using Core.Service.Abstract;
using Dto.Concrete.CreditCard;
using Dto.Concrete.Payment.CreditCard;
using Entity.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private ICustomerService _customerService;
        private ICreditCardService _creditCardService;

        public AccountController(IService<Account,
            string> accountService, 
            IAccountService accountService1,
            ICustomerService customerService,
            ICreditCardService creditCardService)
        {
            _accountService = accountService1;
            _customerService = customerService;
            _creditCardService = creditCardService;
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetCustomerCards(string customerId)
        {
            var result =await _accountService.GetCustomerCards(customerId);
            return result.Success ? Ok(result) : NotFound();
        }     
             
        
        [HttpPost("[action]")]
        public async Task<IActionResult> GetCustomerCard(GetCardDto cardDto)
        {
            var customer = await _customerService.GetByFullname(cardDto.Firstname, cardDto.Lastname);

            var result =await _accountService.GetCustomerCard(
                x => x.AccountId== customer.Data.AccountId
                    &&x.Number.Trim().Equals(cardDto.Number)
                    && x.Cvv == cardDto.Cvv
                    && x.Month == cardDto.Month
                    && x.Year == cardDto.Year);
            return result.Success ? Ok(result) : NotFound();
        }          
        
        [HttpGet("[action]/{cardId}")]
        public async Task<IActionResult> GetCardWithDetails(string cardId)
        {
            var result = await _creditCardService.GetCardWithDetails(cardId);

           
            return result.Success ? Ok(result) : NotFound();
        }     
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCreditCard( CreditCardDto creditCardDto)
        {
            var result =await _accountService.CreateCreditCard(creditCardDto);
            return result.Success ? Ok(result) : NotFound();
        }
    }
}
