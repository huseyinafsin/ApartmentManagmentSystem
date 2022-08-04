using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class UserMessage : BaseEntity, IEntity
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
    }
}
