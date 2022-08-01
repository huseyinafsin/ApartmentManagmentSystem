using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Core.Repository;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete;

namespace Bussiness.Concrete
{
    public class TenantService : Service<Tenant>, ITenantService
    {
        private readonly IRepository<Tenant> _residentRepository;
        private readonly IMapper _mapper;
        public TenantService(IRepository<Tenant> repository, IRepository<Tenant> residentRepository, IMapper mapper) : base(repository)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<TenantModelDto>>> GetResidents()
        {
            var residents = await _residentRepository.GetAll();

            var mappedResidents = _mapper.Map<List<TenantModelDto>>(residents);
            return new SuccessDataResult<List<TenantModelDto>>(){Data = mappedResidents};
        }
    }
}
