using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.Apartment.Bill;
using Dto.Concrete.Dtos.Bill;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Abstracts.Apartment
{
    public interface IBillService : IService<Bill, int>
    {
        Task<IDataResult<BillModelDto>> GetWithDetails(int id);
        Task<IDataResult<List<BillModelDto>>> GetAllWithDetails();
        Task<IDataResult<List<BillModelDto>>> GetTenantBills(int id);
        Task<IResult> CreateBill( MultiBillCreateDto multiBillCreateDto);
    }
}
