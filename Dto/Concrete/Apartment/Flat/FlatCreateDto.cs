using Core.Abstract;

namespace Dto.Concrete.Dtos.Flat
{
    public class FlatCreateDto : IDto
    {
        public int TenantId { get; set; }
        public int FlatTypeId { get; set; }
        public double MonthlyPrice { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsInUse { get; set; }
    }
}