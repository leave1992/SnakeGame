using Snake.DataAccess.Repositories;
using Snake.Game.Models;

namespace Snake.DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
