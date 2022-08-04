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
    public class MongoDbRepository<T> : IRepository<T> where T : class, IMongoEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;

        public MongoDbRepository(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
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
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await Collection.Find(_ =>true).ToListAsync() :
              await Collection.Find(expression).ToListAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
