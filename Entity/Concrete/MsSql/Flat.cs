using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class Flat : BaseEntity
    {
        public int? TenantId { get; set; }
        public int FlatTypeId { get; set; }
        public double MonthlyPrice { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsInUse { get; set; }

        public virtual Tenant? Tenant { get; set; } 
        public virtual FlatType FlatType { get; set; } 

    }
}
