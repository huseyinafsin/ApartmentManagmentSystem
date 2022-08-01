using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class UserMessage : BaseEntity, IEntity
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
    }
}
