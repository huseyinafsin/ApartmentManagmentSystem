using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.CreditCard;
using Entity.Mongo;

namespace Bussiness.Abstracts.Payment
{
    public interface IAccountService :IService<Customer,string>
    {
        Task<IDataResult<List<CreditCard>>> GetCustomerCards(string customerId);
        Task<IDataResult<CreditCard>> GetCustomerCard(Expression<Func<CreditCard, bool>> expression);
        Task<IDataResult<CreditCard>> CreateCreditCard( CreditCardDto creditCardDto);
    }
}