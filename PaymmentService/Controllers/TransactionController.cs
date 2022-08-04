using System;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Dto.Concrete.Payment;
using Entity.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IService<Transaction,string> _transactionService;

        public TransactionController(IService<Transaction,string> transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(TransactionCreateModel createModel)
        {
            var transaction = new Transaction()
            {
                Amount = createModel.Amount,
                CredditCardId = createModel.CredditCardId,
                PaymentDetails = createModel.PaymentDetails,
                CreatedAt = DateTime.Now,
                Status = true

            };
            var result = await _transactionService.AddAsync(transaction);

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll( )
        {
            var result = await _transactionService.GetAllAsync();

            return Ok(result);
        }
    }
}
