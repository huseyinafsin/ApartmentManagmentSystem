using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class Bill : BaseEntity
    {
        public int ResidentId { get; set; }
        public int BillTypeId { get; set; }
        public double Amount { get; set; }
        public bool Paid { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual BillType BillType { get; set; }
    }


}
