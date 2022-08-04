using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete.MsSql;

namespace Bussiness.Concrete.Apartment
{
    public class TenantService : Service<Tenant, int>, ITenantService
    {
        private readonly IRepository<Tenant> _residentRepository;
        private readonly IMapper _mapper;
        public TenantService(IRepository<Tenant> repository, IRepository<Tenant> residentRepository, IMapper mapper) : base(repository)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<TenantModelDto>>> GetTenants()
        {
            var residents = await _residentRepository.GetAll();

            var mappedResidents = _mapper.Map<List<TenantModelDto>>(residents);
            return new SuccessDataResult<List<TenantModelDto>>(){Data = mappedResidents};
        }

    }
}
