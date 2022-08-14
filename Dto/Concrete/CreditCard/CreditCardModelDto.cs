using Core.Abstract;

namespace Dto.Concrete.CreditCard
{
    public class CreditCardModelDto : IDto
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }
    }
}