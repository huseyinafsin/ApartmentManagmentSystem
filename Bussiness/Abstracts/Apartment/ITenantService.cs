using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts.Apartment
{
    public interface ITenantService : IService<Tenant,int>
    {
        Task<IDataResult<List<TenantModelDto>>> GetAllWithDetails();
        Task<IDataResult<TenantModelDto>> GetWithDetails(int id);
        Task<IDataResult<TenantModelDto>> AddTenant(TenantForRegister tenantForRegister);
    }
}

