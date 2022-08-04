using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts
{
    public interface ITenantService : IService<Tenant>
    {
        Task<IDataResult<List<TenantModelDto>>> GetTenants();
    }
}

