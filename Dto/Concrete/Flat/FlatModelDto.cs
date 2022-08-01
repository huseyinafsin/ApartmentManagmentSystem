using Core.Abstract;

namespace Dto.Concrete.Dtos.Flat
{
    public class FlatDetailModelDto : IDto
    {

        public double MonthlyPrice { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsInUse { get; set; }
        public string TenantFirstname { get; set; }
        public string TenantLastname { get; set; }
        public string FlatType{ get; set; }

    }
}