using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete.MsSql;

namespace DataAccess.Abstract.Apartment
{
    public interface ITenatRepository : IRepository<Tenant>
    {
        Task<List<Tenant>> GetAllWithDetails();

    }
}
