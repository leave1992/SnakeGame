using Snake.DataAccess.Repositories;
using Snake.Game.Models;

namespace Snake.DataAccess
{
    public interface IUnitOfWork
    {
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Scores> ScoresRepository { get; }
        void Save();
    }
}
