using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.User;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete.Apartment
{
    public class UserService : Service<User, int>, IUserService
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            var user = this._userRepository.GetWithDetails(x=>x.Email==email);
            if (user == null)
                return new ErrorDataResult<User>("User not found");

            return new SuccessDataResult<User>(data: user);
        }

        public async Task<IDataResult<User>> GetById(int id)
        {
            var user = this._userRepository.GetWithDetails(x => x.Id == id);
            if (user == null)
                return new ErrorDataResult<User>("User not found");

            return new SuccessDataResult<User>(data: user);
        }


        public async Task<IDataResult<List<UserModel>>> GetAll()
        {
            var users = await _repository.GetAll();
            var mapped = _mapper.Map<List<UserModel>>(users);
   
            return new SuccessDataResult<List<UserModel>>(mapped);
        }
    }
}