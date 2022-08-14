using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Concrete.Apartment.Payment
{
    internal class PaymentCreateDto
    {
        public string CreditCardId { get; set; }
        public int BillId { get; set; }
   
    }
}
