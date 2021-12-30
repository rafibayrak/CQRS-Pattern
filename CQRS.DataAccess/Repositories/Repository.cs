using CQRS.Data;
using CQRS.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CQRS.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(MediatorDataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<TEntity>> AddRangeAsync(IQueryable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var list = await _context.Set<TEntity>().ToListAsync();
            return list.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> Include<T>(Expression<Func<TEntity, T>> predicate)
        {
            return _context.Set<TEntity>().Include(predicate);
        }

        public IQueryable<TEntity> IncludeWithWhere<T>(Expression<Func<TEntity, T>> predicate, Expression<Func<TEntity, bool>> predicateWhere)
        {
            return _context.Set<TEntity>().Include(predicate).Where(predicateWhere);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
    }
}
