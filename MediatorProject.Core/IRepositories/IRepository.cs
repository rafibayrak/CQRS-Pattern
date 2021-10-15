using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediatorProject.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetByIdAsync(Guid id);
        Task<IQueryable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Include<T>(Expression<Func<TEntity, T>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IQueryable<TEntity>> AddRangeAsync(IQueryable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IQueryable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
