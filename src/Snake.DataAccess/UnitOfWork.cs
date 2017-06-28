using Snake.DataAccess.Repositories;
using Snake.Game.Models;
using System;

namespace Snake.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SnakeDBContext _context;
        private GenericRepository<User> userRepository;
        private GenericRepository<Scores> scoresRepository;

        public UnitOfWork(SnakeDBContext context)
        {
            _context = context;
        }

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Scores> ScoresRepository
        {
            get
            {

                if (this.scoresRepository == null)
                {
                    this.scoresRepository = new GenericRepository<Scores>(_context);
                }
                return scoresRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
