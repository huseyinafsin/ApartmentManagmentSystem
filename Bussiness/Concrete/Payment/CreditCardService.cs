using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstracts.Payment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.CreditCard;
using Entity.Mongo;

namespace Bussiness.Concrete.Payment
{
    public class CreditCardService : Service<CreditCard,string>, ICreditCardService
    {
        private readonly IRepository<CreditCard> _creditCardRepository;
        private readonly IRepository<Customer> _customerRepository;
        public CreditCardService(IRepository<CreditCard> repository, IRepository<CreditCard> creditCardRepository, IRepository<Customer> customerRepository) : base(repository)
        {
            _creditCardRepository = creditCardRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IDataResult<CreditCardModelDto>> GetCardWithDetails(string cardId)
        {
            var card =await _creditCardRepository.GetAsync(x => x.Id == cardId);
            var customer =await _customerRepository.GetAsync(x => x.AccountId == card.AccountId);

            var creditCard = new CreditCardModelDto()
            {
                Firstname =customer.Firstname,
                Lastname = customer.Lastname,
                Number = card.Number,
                Year = card.Year,
                Month = card.Month,
                Cvv = card.Cvv,
            };

            return new SuccessDataResult<CreditCardModelDto>() {Data = creditCard};
        }
    } 
}
