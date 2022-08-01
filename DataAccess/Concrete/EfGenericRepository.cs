using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Repository;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbSet<TEntity> _dbSet;
        public readonly ApartmentContext _context;
        public EfGenericRepository( ApartmentContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;

        }


        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression!=null)
            {
                return await _dbSet.Where(expression).ToListAsync();
            }
            return await _dbSet.ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();

        }

        public async void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression== null)
            {
                return _dbSet.AsQueryable();
            }
            return _dbSet.Where(expression).AsQueryable();
        }
    }
}
