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
using Dto.Concrete.User;

namespace Bussiness.Concrete.Apartment
{
    public class UserService : Service<User, int>, IUserService
    {

        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }


        public async Task<IDataResult<User>> GetByEmailAndPassword(string email, string password)
        {
            var user = this._repository.Where(w => w.Email.Equals(email) && password.Equals(password)).SingleOrDefault();
            if (user == null)
                return new ErrorDataResult<User>("User not found");

            return new SuccessDataResult<User>(data:user);
        }

        public async Task<IDataResult<List<UserModel>>> GetAll()
        {
            var users = await _repository.GetAll();
            var mapped = _mapper.Map<List<UserModel>>(users);
   
            return new SuccessDataResult<List<UserModel>>(mapped);
        }
    }
}