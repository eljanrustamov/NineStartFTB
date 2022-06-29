using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EFRepository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null);
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);

        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
        public Task AddAsync(TEntity entity);

    }
}
