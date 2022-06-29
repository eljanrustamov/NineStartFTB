using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    public interface IBaseService<TEntity>
    {
        public Task<TEntity> Get(int? id);
        public Task<List<TEntity>> GetAll();

        public Task Create(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(int? id);
    }
}
