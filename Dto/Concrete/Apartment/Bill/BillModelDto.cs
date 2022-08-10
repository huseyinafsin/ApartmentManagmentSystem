using Core.Abstract;

namespace Dto.Concrete.Dtos.Bill
{
    public class BillModelDto : IDto
    {
        public int ResidentId { get; set; }
        public int BillTypeId { get; set; }
        public double Amount { get; set; }
    }
}