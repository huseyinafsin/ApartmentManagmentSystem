using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dtos.Resident;

namespace Bussiness.Abstracts
{
    public interface IResidentService : IService<Resident>
    {
        Task<IDataResult<List<ResidentModelDto>>> GetResidents();
    }
}

