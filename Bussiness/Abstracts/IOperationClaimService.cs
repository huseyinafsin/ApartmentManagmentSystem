using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service;
using Core.Utilities.Results;

namespace Bussiness.Abstracts
{
    public interface IOperationClaimService : IService<OperationClaim>
    {
        public Task<IDataResult<List<OperationClaim>>> GetUserClaims(int userId);
      
    }
}