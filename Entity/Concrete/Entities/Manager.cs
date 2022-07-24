using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Manager : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual User User { get; set; }

    }
}
