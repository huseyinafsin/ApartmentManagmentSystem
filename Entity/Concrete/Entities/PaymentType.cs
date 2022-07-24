using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class PaymentType : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }

    
}
