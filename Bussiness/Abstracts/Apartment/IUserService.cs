using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;
using Dto.Concrete.User;

namespace Bussiness.Abstracts.Apartment
{
    public interface IUserService :IService<User, int>
    {
        public Task<IDataResult<User>> GetByEmail(string email);
        public Task<IDataResult<User>> GetById(int id);
        public Task<IDataResult<List<UserModel>>> GetAll();
    }
}