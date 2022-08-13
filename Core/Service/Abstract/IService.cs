using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Abstract
{

    public interface IService<TEntity,TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        Task<IDataResult<TEntity>> GetByIdAsync(TKey id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<IResult> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<TEntity>> AddAsync(TEntity entity);
        Task<IDataResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        IDataResult<TEntity> Update(TEntity entity);
        Task<IResult> RemoveAsync(int id);
        Task<IResult> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
