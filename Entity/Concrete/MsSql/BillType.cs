using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class BillType : BaseEntity, IEntity
    {
        public string Name { get; set; }

    }


}
