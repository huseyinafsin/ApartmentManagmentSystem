using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Core.Repository;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dtos.Resident;

namespace Bussiness.Concrete
{
    public class ResidentService : Service<Resident>, IResidentService
    {
        private readonly IRepository<Resident> _residentRepository;
        private readonly IMapper _mapper;
        public ResidentService(IRepository<Resident> repository, IRepository<Resident> residentRepository, IMapper mapper) : base(repository)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<ResidentModelDto>>> GetResidents()
        {
            var residents = await _residentRepository.GetAll();

            var mappedResidents = _mapper.Map<List<ResidentModelDto>>(residents);
            return new SuccessDataResult<List<ResidentModelDto>>(){Data = mappedResidents};
        }
    }
}
