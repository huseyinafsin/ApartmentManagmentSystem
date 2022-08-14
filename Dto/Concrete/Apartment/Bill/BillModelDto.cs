using Core.Abstract;

namespace Dto.Concrete.Dtos.Bill
{
    public class BillModelDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string BillType { get; set; }
        public double Amount { get; set; }
        public bool Paid { get; set; }
    }
}