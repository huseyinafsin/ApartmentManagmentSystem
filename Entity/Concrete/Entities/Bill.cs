using Core.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Bill : BaseEntity, IEntity
    {
        public int ResidentId { get; set; }
        public int BillTypeId { get; set; }
        public int PaymetTypeId { get; set; }
        public double Amount { get; set; }
        
    }    

    
}
