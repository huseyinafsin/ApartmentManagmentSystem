using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Flat;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete.MsSql;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete.Apartment
{
    public class FlatService : Service<Flat, int>, IFlatService
    {
        private readonly IMapper _mapper;
        public FlatService(IRepository<Flat> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<IDataResult<List<FlatModelDto>>> GetAllWithDetails()
        {
            var result = _repository
                .Where()
                .Include(x => x.FlatType)
                .ToList();
            var mapperResult = _mapper.Map<List<FlatModelDto>>(result);

            return new SuccessDataResult<List<FlatModelDto>>() { Data = mapperResult };
        }

        public async Task<IDataResult<FlatModelDto>> Create(FlatCreateDto createDto)
        {
            var flat = _mapper.Map<Flat>(createDto);

            var result = await _repository.AddAsync(flat);

            var flatModel = _mapper.Map<FlatModelDto>(result);

            return new SuccessDataResult<FlatModelDto>() { Data = flatModel };
        }

        public async Task<IDataResult<FlatModelDto>> GetWithDetails(int id)
        {
            var result = _repository
                .Where()
                .Include(x => x.FlatType)
                .FirstOrDefault(x=>x.Id==id);
            var mapperResult = _mapper.Map<FlatModelDto>(result);

            return new SuccessDataResult<FlatModelDto>() { Data = mapperResult };
        }
    }
}
