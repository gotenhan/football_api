using System;
using System.Data;
using System.Data.Entity;
using FootballApi.Data;

namespace FootballApi.Domain.Repositories
{
    public class AddGameResultUnitOfWork : IAddGameResultUnitOfWork
    {
        private readonly FootballApiContext _footbalApiContext;
        private DbContextTransaction _transaction;
        public IGameResultRepository GameResultRepository { get; }
        public ITeamRepository TeamRepository { get; }

        public AddGameResultUnitOfWork(FootballApiContext footbalApiContext)
        {
            _footbalApiContext = footbalApiContext;
            _transaction = _footbalApiContext.Database.BeginTransaction(IsolationLevel.Serializable);
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new ObjectDisposedException("Unit of work has been completed or rolled back already");

            _footbalApiContext.SaveChanges();
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public void RollbackChanges()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            RollbackChanges();
        }
    }
}