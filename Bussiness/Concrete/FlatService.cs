using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Core.Repository;
using Core.Service;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete
{
    public class FlatService :  Service<Flat>, IFlatService
    {
        private readonly IMapper _mapper;
        public FlatService(IRepository<Flat> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<IDataResult<List<FlatDetailModelDto>>> GetAllWithDetails()
        {
            var result = _repository
                .Where()
                .Include(x => x.Tenant)
                .ThenInclude(x => x.User)
                .Include(x => x.FlatType)
                .ToList();
          var mapperResult = _mapper.Map<List<FlatDetailModelDto>>(result);

          return new SuccessDataResult<List<FlatDetailModelDto>>() { Data = mapperResult };
        }
    }
}
