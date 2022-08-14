using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstracts.Payment;
using Core.Repository;
using Core.Service.Abstract;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Customer;
using Entity.Mongo;
using ServiceStack;

namespace Bussiness.Concrete.Payment
{
    public class CustomerService : Service<Customer,string>, ICustomerService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> repository, IRepository<Account> accountRepository, IRepository<Customer> customerRepository) : base(repository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IDataResult<Customer>> CreateCustomer(CustomerCreateDto customerCreate)
        {
            var account = new Account()
            {
                Balance = 5000
            };
           var newAccount =await _accountRepository.AddAsync(account);

           var customer = new Customer()
           {
               Firstname = customerCreate.Firstname,
               Lastname = customerCreate.Lastname,
               AccountId = newAccount.Id
           };

           var newCustomer =await _repository.AddAsync(customer);

           return new SuccessDataResult<Customer>() {Data = newCustomer};
        }

        public async Task<IDataResult<Customer>> GetByFullname(string firstname, string lastname)
        {
            var result =await _customerRepository.GetAsync(x => x.Firstname.Equals(firstname)
            && x.Lastname.Equals(lastname));

            return new SuccessDataResult<Customer>() {Data = result};
        }
    }


}
