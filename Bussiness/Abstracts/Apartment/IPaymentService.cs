using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Dto.Concrete.Payment;
using Dto.Concrete.Payment.Payment;
using Dto.Concrete.Payment.Transaction;
using Entity.Mongo;

namespace Bussiness.Abstracts.Apartment
{
    public interface IPaymentService 
    {
        Task<IDataResult<Transaction>> Pay(PaymentCreateDto transactionCreateDto);
    }
}
