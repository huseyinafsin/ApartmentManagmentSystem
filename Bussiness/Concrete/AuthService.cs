using AutoMapper;
using Bussiness.Abstracts;
using Core.Entity.Concrete;
using Core.Service;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Autofac.Core.Activators.Reflection;
using Bussiness.Configuration.Interceptors;
using Core.Utilities.Security.Hashing;

namespace Bussiness.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IService<Manager> _managerService;
        private readonly IService<Resident> _residentService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;


        public AuthService(IMapper mapper, ITokenHelper tokenHelper, IUserService userService, IService<Manager> managerService, IOperationClaimService operationClaimService, IService<Resident> residentService)
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
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
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

        public async Task<IDataResult<AccessToken>> ResidentRegister(ResidentForRegister residentForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(residentForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = residentForRegister.Email,
                Firstname = residentForRegister.Firstname,
                Lastname = residentForRegister.Lastname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var operationClaims = _operationClaimService.Where(w => w.Id == 2).ToList();

             _userService.AddAsync(user);
            var resident = new Resident()
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
