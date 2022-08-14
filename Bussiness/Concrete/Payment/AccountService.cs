using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Payment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.CreditCard;
using Entity.Mongo;

namespace Bussiness.Concrete.Payment
{
    public class AccountService : Service<Customer, string>, IAccountService
    {
        private readonly IRepository<CreditCard> _creditCardsRepository;
        private readonly ICustomerService _customerService;
        private IMapper _mapper;
        public AccountService(IRepository<Customer> repository, IRepository<CreditCard> creditCardsRepository, ICustomerService customerService, IMapper mapper) : base(repository)
        {
            _creditCardsRepository = creditCardsRepository;
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<CreditCard>>> GetCustomerCards(string customerId)
        {
            Customer customer;
            try
            {
                customer = _customerService.GetByIdAsync(customerId).Result.Data;

            }
            catch (Exception C)
            {
                Console.WriteLine(C);
                throw;
            }
            var result = await _creditCardsRepository.GetAll(x => x.AccountId.Equals(customer.AccountId));

            return new SuccessDataResult<List<CreditCard>>() { Data = result };
        }

        public async Task<IDataResult<CreditCard>> GetCustomerCard(Expression<Func<CreditCard, bool>> expression)
        {
            var result = await _creditCardsRepository.GetAsync(expression);

            return new SuccessDataResult<CreditCard>() { Data = result };
        }

        public async Task<IDataResult<CreditCard>> CreateCreditCard(CreditCardDto creditCardDto)
        {
            var customer = await _customerService.GetByIdAsync(creditCardDto.CustomerId);

            var creditCard = _mapper.Map<CreditCard>(creditCardDto);
            creditCard.AccountId = customer.Data.AccountId;
            var result = await _creditCardsRepository.AddAsync(creditCard);
            return new SuccessDataResult<CreditCard>() { Data = result };
        }
    }
}