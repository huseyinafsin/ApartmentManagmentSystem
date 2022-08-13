using Core.Abstract;
using Entity.Concrete.MsSql;

namespace Dto.Concrete.Dtos.Flat
{
    public class FlatModelDto : IDto
    {

        public int Id { get; set; }
        public double MonthlyPrice { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsInUse { get; set; }
        public string TenantFirstname { get; set; }
        public string TenantLastname { get; set; }
        public FlatType FlatType{ get; set; }

    }
}