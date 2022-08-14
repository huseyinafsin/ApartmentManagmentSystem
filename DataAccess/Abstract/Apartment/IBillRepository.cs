using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Entity.Concrete.MsSql;

namespace DataAccess.Abstract.Apartment
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<List<Bill>> GetAllWithDetails(Expression<Func<Bill, bool>> expression =null);
        Task<Bill> GetWithDetails(Expression<Func<Bill, bool>> expression);
    }
}
