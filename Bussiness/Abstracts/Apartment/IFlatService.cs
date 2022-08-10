using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts.Apartment
{
    public interface IFlatService : IService<Flat,int>
    {
        public  Task<IDataResult<List<FlatModelDto>>> GetAllWithDetails();
        public  Task<IDataResult<FlatModelDto>> Create( FlatCreateDto createDto);
    }
}
