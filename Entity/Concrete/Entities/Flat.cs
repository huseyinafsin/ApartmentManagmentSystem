using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Flat : BaseEntity, IEntity
    {
        public int ResidentId { get; set; }
        public int FlatTypeId { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsInUse { get; set; }

        public virtual Resident Resident { get; set; }
        public virtual FlatType FlatType { get; set; }

    }
}
