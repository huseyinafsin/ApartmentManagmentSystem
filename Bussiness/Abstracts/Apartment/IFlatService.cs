using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Flat;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts.Apartment
{
    public interface IFlatService : IService<Flat,int>
    {
        Task<IDataResult<List<FlatModelDto>>> GetAllWithDetails();
        Task<IDataResult<FlatModelDto>> Create( FlatCreateDto createDto);
        Task<IDataResult<FlatModelDto>> GetWithDetails(int id);
    }
}
