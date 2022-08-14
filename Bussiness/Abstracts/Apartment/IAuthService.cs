using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Dto.Concrete.User;

namespace Bussiness.Abstracts.Apartment
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin);
        public Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister);
        //public Task<IDataResult<AccessToken>> TenantRegister(TenantForRegister tenantForRegister);
       public Task<IDataResult<AccessToken>> ChangePassword(int id, string password);
    }
}
