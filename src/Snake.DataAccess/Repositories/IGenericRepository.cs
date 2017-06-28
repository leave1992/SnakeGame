using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Snake.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
                    Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "");

        //Method to add row to the table
        void Insert(TEntity entity);

        //Method to fetch row from the table
        TEntity GetByID(object id);

        //Method to update a row in the table
        void Update(TEntity entity);

        //Method to delete a row from the table
        void Delete(TEntity entity);
    }
}
