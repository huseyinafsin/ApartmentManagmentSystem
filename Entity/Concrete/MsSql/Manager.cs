using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class Manager : BaseEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual User User { get; set; }

    }
}
