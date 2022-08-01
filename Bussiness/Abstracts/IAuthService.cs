using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using System.Text;
using System.Threading.Tasks;
using Dto.Concrete.User;

namespace Bussiness.Abstracts
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin);
        public Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister);
        public Task<IDataResult<AccessToken>> TenantRegister(TenantForRegister residentForRegister);
    }
}
