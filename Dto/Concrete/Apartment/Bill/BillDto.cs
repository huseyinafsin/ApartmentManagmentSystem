using Core.Abstract;

namespace Dto.Concrete.Apartment.Bill
{
    public class BillDto : IDto
    {
        public int BillTypeId { get; set; }
        public double Amount { get; set; }
    }
}