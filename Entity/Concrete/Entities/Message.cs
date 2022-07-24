using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Message : BaseEntity, IEntity
    {
        public string MessageText { get; set; }

        public bool HasRead { get; set; }
    }    
}
