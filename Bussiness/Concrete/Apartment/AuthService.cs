using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;

namespace Bussiness.Concrete.Apartment
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IService<Manager, int> _managerService;
        private readonly IService<Tenant,int> _residentService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;


        public AuthService(IMapper mapper, ITokenHelper tokenHelper, IUserService userService, IService<Manager, int> managerService, IOperationClaimService operationClaimService, IService<Tenant, int> residentService)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenHelper = tokenHelper;
            _managerService = managerService;
            _operationClaimService = operationClaimService;
            _residentService = residentService;
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin)
        {
            var user =await _userService.GetByEmailAndPassword(userForLogin.Email, userForLogin.Password);
            if (user.Success)
            {
                var userOpertaitonClaims =await _operationClaimService.GetUserClaims(user.Data.Id);
                var accessoken = _tokenHelper.CreateToken(user.Data, userOpertaitonClaims.Data);

                return new SuccessDataResult<AccessToken>(accessoken);
            }

            return new ErrorDataResult<AccessToken>("Login failed");
        }

        public async Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(managerForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = managerForRegister.Email,
                Firstname = managerForRegister.Firstname,
                Lastname = managerForRegister.Lastname,
                Status = true
            };
            var operationClaims = _operationClaimService.Where(w => w.Id == 1).ToList();

            await _userService.AddAsync(user);
            var manager = new Manager()
            {
                User = user,
                Username = managerForRegister.Username
            };
            await _managerService.AddAsync(manager);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken> { Data = accessToken };
        }

        public async Task<IDataResult<AccessToken>> TenantRegister(TenantForRegister residentForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(residentForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = residentForRegister.Email,
                Firstname = residentForRegister.Firstname,
                Lastname = residentForRegister.Lastname,
                Pasword = new Password()
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                },
                Status = true
            };
            var operationClaims = _operationClaimService.Where(w => w.Id == 2).ToList();

             var resident = new Tenant()
            {
                User = user,
                IdentityNumber = residentForRegister.IdentityNumber,
                HasACar = residentForRegister.HasACar,
                Phone = residentForRegister.Phone,
                Plate = residentForRegister.Plate,
            };
            _residentService.AddAsync(resident);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken> { Data = accessToken };
        }
    }
}
