using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entity.Concrete;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentService.Models;

namespace DataAccess.Concrete
{
    public class MongoDbRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity<string>, new()
    {
        protected readonly IMongoCollection<TEntity> Collection;
        private readonly MongoDbSettings settings;

        public MongoDbRepository(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

        //public virtual async Task<T> Get(Expression<Func<T, bool>> predicate )
        //{
        //    return await Collection.AsQueryable().FirstOrDefaultAsync(predicate);
        //}

        //public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        //{
        //    return predicate ==null ?  await Collection.AsQueryable().Where(predicate).ToListAsync() :
        //     await Collection.AsQueryable().ToList().AsQueryable().ToListAsync();
        //}

        //public virtual async Task<T> AddAsync(T entity)
        //{
        //    var options = new InsertOneOptions { BypassDocumentValidation = false };
        //    await Collection.InsertOneAsync(entity, options);
        //    return entity;
        //}

        //public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
        //    return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        //}

        //public virtual async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        //{
        //    return await Collection.FindOneAndReplaceAsync(predicate, entity);
        //}

        //public virtual async Task<T> DeleteAsync(T entity)
        //{
        //    return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        //}

        //public virtual async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await Collection.FindOneAndDeleteAsync(filter);
        //}
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(expression);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await Collection.Find(_ =>true).ToListAsync() :
              await Collection.Find(expression).ToListAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
