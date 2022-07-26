using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Service;
using Core.Utilities.Results;

namespace Bussiness.Abstracts
{
    public interface IUserService :IService<User>
    {
        public Task<IDataResult<User>> GetByEmailAndPassword(string ermail, string password);
    }
}