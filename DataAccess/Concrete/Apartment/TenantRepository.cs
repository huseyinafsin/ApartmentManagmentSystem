using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Apartment;
using DataAccess.Contexts;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete.MsSql;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Apartment
{
    public class TenantRepository : EfGenericRepository<Tenant>, ITenatRepository
    {
        public TenantRepository(ApartmentContext context) : base(context)
        {
        }

        public async Task<List<Tenant>> GetAllWithDetails()
        {
            return await _context.Tenants
                .Include(x => x.User)
                .ThenInclude(t => t.Pasword).ToListAsync();
        }

        public async Task<Tenant> GetWithDetails(Expression<Func<Tenant, bool>> expression)
        {
            return  _context.Tenants
                .Include(x => x.Flat)
                .Include(x => x.User)
                .ThenInclude(t => t.Pasword).FirstOrDefault(expression);
        }
    }
}
