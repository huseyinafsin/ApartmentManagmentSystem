using AutoMapper;
using Core.Entity.Concrete;
using Core.Service;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstracts
{
    public class IAuthService
    {
        private readonly IService<User> _userService;
        private readonly IService<OperationClaim> _operationClaimService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;


        public IAuthService(IMapper mapper, ITokenHelper tokenHelper, IService<User> userService)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenHelper = tokenHelper;


        }

        Task<IDataResult<string>> Login(UserForLogin userForLogin)
        {
            throw new NotImplementedException();
        } 
        
        //Task<IDataResult<string>> ManagerRegister(ManagerForRegister managerForRegister)
        //{
        //    var user = _mapper.Map<User>(managerForRegister);
        //    var operationClaims = _operationClaimService.AddAsync(new OperationClaim { Name="Admin"})
        //    var loginResult = _tokenHelper.CreateToken(user, )

        //}

    }
}
