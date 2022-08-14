using System.Collections.Generic;
using Core.Abstract;

namespace Dto.Concrete.Apartment.Bill
{
    public class MultiBillCreateDto : IDto
    {
        public int TenantId { get; set; }
        public List<BillDto> Bills { get; set; }
    }
}