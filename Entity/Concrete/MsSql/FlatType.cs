using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class FlatType : BaseEntity, IEntity
    {
        public string Type { get; set; }
    }
}
