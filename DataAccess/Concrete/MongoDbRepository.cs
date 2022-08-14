using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entity.Concrete;
using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ServiceStack;

namespace DataAccess.Concrete
{
    public class MongoDbRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity<string>, new()
    {
        protected readonly IMongoCollection<TEntity> Collection;
        private readonly MongoDbSettings settings;

        public MongoDbRepository(Microsoft.Extensions.Options.IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

       
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            //return await Collection.AsQueryable().FirstOrDefaultAsync(expression);
            return await Collection.Find(expression).FirstOrDefaultAsync();
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

        public TEntity Update(TEntity entity)
        {
            var result = Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity).Result;
            return null;
        }


        public Task Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
