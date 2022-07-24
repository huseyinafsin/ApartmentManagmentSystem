using Core.Abstract;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
