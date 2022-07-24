using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class FlatType : BaseEntity, IEntity
    {
        public string Type { get; set; }
    }
}
