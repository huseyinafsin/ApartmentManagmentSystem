using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Customer;
using Entity.Mongo;

namespace Bussiness.Abstracts.Payment
{
    public interface ICustomerService : IService<Customer,string>
    {
         Task<IDataResult<Customer>> CreateCustomer(CustomerCreateDto createDto);
         Task<IDataResult<Customer>> GetByFullname(string firstname, string lastname);
    }
}
