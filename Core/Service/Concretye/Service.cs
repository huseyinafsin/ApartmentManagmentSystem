using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Constants;
using Core.Exceptions;
using Core.Repository;
using Core.Service.Abstract;
using Core.Utilities.Results;

namespace Core.Service.Concretye
{
    public class Service<TEntity,TKey> : IService<TEntity,TKey> where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        public async Task<IDataResult<TEntity>> GetByIdAsync(TKey id)
        {
            var result = await _repository.GetAsync(x => x.Id.Equals(id));

            if (result == null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name}({id}) not found");
            }

            return new SuccessDataResult<TEntity>(result, typeof(TEntity).Name + " " + Messages.EntityFetched);
        }


        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<IDataResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var result = await _repository.GetAll();
            return new SuccessDataResult<IEnumerable<TEntity>>(result, typeof(TEntity).Name + " " + Messages.EntityListed);

        }

        public async Task<IResult> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _repository.AnyAsync(expression);
            if (result)
                return new SuccessResult();

            return new SuccessResult();

        }

        public async Task<IDataResult<TEntity>> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            return new SuccessDataResult<TEntity>(entity, typeof(TEntity).Name + " " + Messages.EntityAdded);
        }

        public async Task<IDataResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            return new SuccessDataResult<IEnumerable<TEntity>>(entities, typeof(TEntity).Name + " " + Messages.EntityAdded);
        }

        public IDataResult<TEntity> Update(TEntity entity)
        {
           var result = _repository.Update(entity);
           return new SuccessDataResult<TEntity>(result, typeof(TEntity).Name + " " + Messages.EntityUpdated);
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id.Equals(id));
           await _repository.Remove(entity);
            return new SuccessResult(typeof(TEntity).Name + " " + Messages.EntityDeleted);
        }

        public async Task<IResult> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
          await  _repository.RemoveRange(entities);
            return new SuccessResult(typeof(TEntity).Name + " " + Messages.EntityDeleted);

        }
    }
}
