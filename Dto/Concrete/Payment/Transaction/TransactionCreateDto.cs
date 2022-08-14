using Core.Abstract;

namespace Dto.Concrete.Payment.Transaction
{
    public class TransactionCreateDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }
        public double Amount { get; set; }
        public string PaymentDetails { get; set; }

    }
}
