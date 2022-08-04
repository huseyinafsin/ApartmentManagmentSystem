﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete.MsSql;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete.Apartment
{
    public class FlatService :  Service<Flat, int>, IFlatService
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