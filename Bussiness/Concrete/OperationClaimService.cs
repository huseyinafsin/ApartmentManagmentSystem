using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Abstracts;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service;
using Core.Utilities.Results;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete
{
    public class OperationClaimService : Service<OperationClaim>, IOperationClaimService
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
