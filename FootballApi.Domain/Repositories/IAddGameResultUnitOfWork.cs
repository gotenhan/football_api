using System;

namespace FootballApi.Domain.Repositories
{
    public interface IAddGameResultUnitOfWork: IDisposable
    {
        IGameResultRepository GameResultRepository { get; }
        ITeamRepository TeamRepository { get; }

        void SaveChanges();
        void RollbackChanges();
    }
}