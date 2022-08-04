using System.Linq;
using System.Threading.Tasks;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service.Concretye;
using Core.Utilities.Results;

namespace Bussiness.Concrete.Apartment
{
    public class UserService : Service<User, int>, IUserService
    {
        
        public UserService(IRepository<User> repository) : base(repository)
        {
        }


        public async Task<IDataResult<User>> GetByEmailAndPassword(string email, string password)
        {
            var user = this._repository.Where(w => w.Email.Equals(email) && password.Equals(password)).SingleOrDefault();
            if (user == null)
                return new ErrorDataResult<User>("User not found");

            return new SuccessDataResult<User>(data:user);
        }
    }
}