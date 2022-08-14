using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using DataAccess.Abstract.Apartment;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Apartment
{
    public class UserRepository : EfGenericRepository<User>,IUserRepository
    {
        public UserRepository(ApartmentContext context) : base(context)
        {
        }


        public User GetWithDetails(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Include(x => x.Pasword).SingleOrDefault(expression);
        }
    }
}
