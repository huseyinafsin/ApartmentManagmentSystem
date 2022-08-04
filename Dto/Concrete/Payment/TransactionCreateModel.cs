using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Concrete.Payment
{
    public class TransactionCreateModel
    {
        public int CredditCardId { get; set; }
        public string PaymentDetails { get; set; }
        public int Amount { get; set; }
    }
}
