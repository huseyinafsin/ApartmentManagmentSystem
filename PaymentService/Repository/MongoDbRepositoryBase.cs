using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentService.Models;

namespace PaymentService.Repository
{
    public abstract class MongoDbRepositoryBase<T> : IRepository<T> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;

        protected MongoDbRepositoryBase(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }


        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefaultAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? IAsyncCursorSourceExtensions.ToListAsync(Collection.AsQueryable())
                : EntityFrameworkQueryableExtensions.ToListAsync(Collection.AsQueryable().Where(expression));
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

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
              Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options);
              return entities;
        }

        public async void Update(T entity)
        {
             await Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
             
        }

        public void Remove(T entity)
        {
            Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            
        }
    }
}
