using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Dto.Concrete.Payment.CreditCard
{
    public class GetCardDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public int Cvv { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
