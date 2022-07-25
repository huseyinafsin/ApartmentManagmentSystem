using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete.Dtos;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstracts
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> Login(UserForLogin userForLogin);
        public Task<IDataResult<AccessToken>> ManagerRegister(ManagerForRegister managerForRegister);
        public Task<IDataResult<AccessToken>> ResidentRegister(ResidentForRegister residentForRegister);
    }
}
