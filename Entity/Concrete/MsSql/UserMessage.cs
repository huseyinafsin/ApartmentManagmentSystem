using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete.MsSql
{
    public class UserMessage : BaseEntity
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
        public virtual Message Message { get; set; }
    }
}
