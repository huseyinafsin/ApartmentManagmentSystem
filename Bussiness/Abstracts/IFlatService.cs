using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core.Utilities.Results;
using Dto.Concrete.Dtos.Flat;
using Entity.Concrete.MsSql;

namespace Bussiness.Abstracts
{
    public interface IFlatService : IService<Flat>
    {
        public  Task<IDataResult<List<FlatDetailModelDto>>> GetAllWithDetails();
    }
}
