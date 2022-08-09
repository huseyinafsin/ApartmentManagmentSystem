using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Bussiness.Configuration.Constants;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;

namespace Bussiness.Concrete.Apartment
{
    public class TenantService : Service<Tenant, int>, ITenantService
    {
        private readonly ITenatRepository _tenantRepository;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;
        public TenantService(IRepository<Tenant> repository, ITenatRepository tenantRepository, IMapper mapper, IOperationClaimService operationClaimService) : base(repository)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _operationClaimService = operationClaimService;
        }

        public async Task<IDataResult<List<TenantModelDto>>> GetAllWithDetails()
        {
            var residents = await _tenantRepository.GetAllWithDetails();

            var mappedResidents = _mapper.Map<List<TenantModelDto>>(residents);
            return new SuccessDataResult<List<TenantModelDto>>(){Data = mappedResidents};
        }

        public async Task<IDataResult<TenantModelDto>> GetWithDetails(int id)
        {
            var residents = await _tenantRepository.GetWithDetails(x=>x.Id==id);

            var mappedResidents = _mapper.Map<TenantModelDto>(residents);
            return new SuccessDataResult<TenantModelDto>() { Data = mappedResidents };
        }

        public async Task<IDataResult<TenantModelDto>> AddTenant(TenantForRegister tenantForRegister)
        {
            #region TenantRegister

            var initPassword = GuidHelper.GetRandomPasswordUsingGUID(16);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(tenantForRegister.IdentityNumber, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = tenantForRegister.Email,
                Firstname = tenantForRegister.Firstname,
                Lastname = tenantForRegister.Lastname,
                Pasword = new Password()
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    InitialPassword = initPassword
                },
                Status = true
            };
            var operationClaims = _operationClaimService.Where(w => w.Id == (int)UserType.Tenant).ToList();
            _operationClaimService.SetUserClaim(user.Id, operationClaims);
            var newTenant = new Tenant()
            {
                User = user,
                IdentityNumber = tenantForRegister.IdentityNumber,
                HasACar = tenantForRegister.HasACar,
                Phone = tenantForRegister.Phone,
                Plate = tenantForRegister.Plate,
            };

            var tenant = await _tenantRepository.AddAsync(newTenant);
            var result = _mapper.Map<TenantModelDto>(tenant);

            return new SuccessDataResult<TenantModelDto>(){Data = result};

            #endregion

        }
    }
    
}
