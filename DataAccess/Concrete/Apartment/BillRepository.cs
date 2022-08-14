using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Apartment;
using DataAccess.Contexts;
using Entity.Concrete.MsSql;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

namespace DataAccess.Concrete.Apartment
{
    public class BillRepository : EfGenericRepository<Bill>, IBillRepository
    {
        public BillRepository(ApartmentContext context) : base(context)
        {
        }

        public async Task<List<Bill>> GetAllWithDetails(Expression<Func<Bill, bool>> expression = null)
        {
            return expression == null
                ? await _context.Bills
                    .Include(x => x.Tenant)
                    .ThenInclude(x => x.Flat)
                    .Include(x => x.Tenant)
                    .ThenInclude(x => x.User)
                    .Include(x => x.BillType)
                    .ToListAsync()
                : await _context.Bills
                    .Include(x => x.Tenant)
                    .ThenInclude(x => x.Flat)
                    .Include(x => x.Tenant)
                    .ThenInclude(x => x.User)
                    .Include(x => x.BillType)
                    .Where(expression)
                    .ToListAsync();

        }

        public async Task<Bill> GetWithDetails(Expression<Func<Bill, bool>> expression)
        {
            return await _context.Bills
                .Include(x => x.Tenant)
                .ThenInclude(x => x.User)
                .Include(x => x.BillType)
                .FirstOrDefaultAsync(expression);
        }
    }
}
