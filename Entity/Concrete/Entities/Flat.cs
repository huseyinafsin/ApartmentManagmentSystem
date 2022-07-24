using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Flat : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int TypeId { get; set; }
        public bool IsInUse { get; set; }

    }
}
