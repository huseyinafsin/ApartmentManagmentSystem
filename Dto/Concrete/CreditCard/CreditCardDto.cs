using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Dto.Concrete.CreditCard
{
    public class CreditCardDto : IDto
    {

        public string CustomerId { get; set; }
        public string Number { get; set; }
        public double Debt { get; set; }
        public double Limit { get; set; }
        public int Mont { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }
    }
}
