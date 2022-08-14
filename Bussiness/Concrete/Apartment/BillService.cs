using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Apartment.Bill;
using Dto.Concrete.Dtos.Bill;
using Entity.Concrete.MsSql;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Concrete.Apartment
{
    public class BillService : Service<Bill, int>, IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        public BillService(IRepository<Bill> repository, IBillRepository billRepository, IMapper mapper) : base(repository)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<BillModelDto>> GetWithDetails(int id)
        {
            var result = await _billRepository.GetWithDetails(x => x.Id == id);
            var bill = _mapper.Map<BillModelDto>(result);

            return new SuccessDataResult<BillModelDto>() { Data = bill };
        }



        public async Task<IDataResult<List<BillModelDto>>> GetAllWithDetails()
        {
            var result = await _billRepository.GetAllWithDetails();
            var bills = _mapper.Map<List<BillModelDto>>(result);

            return new SuccessDataResult<List<BillModelDto>>() { Data = bills };
        }

        public async Task<IDataResult<List<BillModelDto>>> GetTenantBills(int id)
        {
            var result = await _billRepository.GetAllWithDetails(x => x.Id == id);
            var bills = _mapper.Map<List<BillModelDto>>(result);

            return new SuccessDataResult<List<BillModelDto>>() { Data = bills };
        }


        public async Task<IResult> CreateBill(MultiBillCreateDto multiBillCreateDto)
        {
            List<Bill> bills = new List<Bill>();

            for (int i = 0; i < multiBillCreateDto.Bills.Count; i++)
            {
                var newBill = new BillCreateDto()   
                {
                    TenantId = multiBillCreateDto.TenantId,
                    Amount = multiBillCreateDto.Bills[i].Amount,
                    BillTypeId = multiBillCreateDto.Bills[i].BillTypeId,
                };
                var bill = _mapper.Map<Bill>(newBill);
                bills.Add(bill);

            }
            var result = _billRepository.AddRangeAsync(bills);
            return new SuccessResult("Bills Crated");



        }
    }
}
