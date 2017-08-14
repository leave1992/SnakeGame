using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snake.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        void Insert(TEntity entity);

        TEntity GetByID(object id);

        void Update(TEntity entity);

        void Delete(object id);
    }
}
