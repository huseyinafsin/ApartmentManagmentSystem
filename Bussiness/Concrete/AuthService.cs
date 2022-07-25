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
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IService<User> _userService;
        private readonly IService<OperationClaim> _operationClaimService;
        private readonly IService<Manager> _managerService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;


        public AuthService(IMapper mapper, ITokenHelper tokenHelper, IService<User> userService, IService<Manager> managerService)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenHelper = tokenHelper;
            _managerService = managerService;


        }

        public async Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister)
        {
            var user = _mapper.Map<User>(managerForRegister);
            var operationClaims = _operationClaimService.Where(w => w.Id == 1).ToList();

            await _userService.AddAsync(user);
            var manager = _mapper.Map<Manager>(managerForRegister);
            await _managerService.AddAsync(manager);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken> { Data = accessToken };
        }

        public Task<IDataResult<AccessToken>> ResidentRegister(ResidentForRegister residentForRegister)
        {
            throw new NotImplementedException();
        }
    }
}
