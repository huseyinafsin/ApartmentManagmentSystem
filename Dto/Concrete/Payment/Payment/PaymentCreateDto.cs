using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Dto.Concrete.Payment.Payment
{
    public class PaymentCreateDto : IDto
    {
        public int BillId { get; set; }
        public int CreditCardId { get; set; }
        public int Amount { get; set; }
    }
}
