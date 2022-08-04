using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service.Abstract;
using Core.Utilities.Results;

namespace Bussiness.Abstracts.Apartment
{
    public interface IUserService :IService<User, int>
    {
        public Task<IDataResult<User>> GetByEmailAndPassword(string ermail, string password);
    }
}