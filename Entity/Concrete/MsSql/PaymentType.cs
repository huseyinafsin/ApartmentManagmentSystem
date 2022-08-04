using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class PaymentType : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }


}
