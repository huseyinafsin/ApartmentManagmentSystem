using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using DataAccess.Contexts;

namespace Bussiness.Concrete.Apartment
{
    public class OperationClaimService : Service<OperationClaim, int>, IOperationClaimService
    {
        private readonly ApartmentContext _context;
        public OperationClaimService(IRepository<OperationClaim> repository, ApartmentContext context) : base(repository)
        {
            _context = context;
        }

        public async Task<IDataResult<List<OperationClaim>>> GetUserClaims(int userId)
        {
            var operationClaims = (from oc in _context.OperationClaims
                from uoc in _context.UserOperationClaims
                where uoc.UserId == userId
                         select oc
                ).ToList();

            return new SuccessDataResult<List<OperationClaim>>(operationClaims);
        }
    }
}
