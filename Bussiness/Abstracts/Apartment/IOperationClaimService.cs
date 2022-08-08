using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;

namespace Bussiness.Abstracts.Apartment
{
    public interface IOperationClaimService : IService<OperationClaim,int>
    {
        public Task<IDataResult<List<OperationClaim>>> GetUserClaims(int userId);
        public void SetUserClaim(int userId, List<OperationClaim> operationClaims);
      
    }
}