﻿using Core.Abstract;

namespace Dto.Concrete.Apartment.Bill
{
    public class BillCreateDto : IDto
    {
        public int TenantId { get; set; }
        public int BillTypeId { get; set; }
        public double Amount { get; set; }
    }
}
