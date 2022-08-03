using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Core.Repository
{
    public interface IMongoDbRepository<T> where T : class, IMongoEntity<string>, new()
    {
        Task<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
