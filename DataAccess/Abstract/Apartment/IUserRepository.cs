using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Repository;

namespace DataAccess.Abstract.Apartment
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
