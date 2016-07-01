namespace FootballApi.Domain.Repositories
{
    public interface IAddGameResultUnitOfWork
    {
        IGameResultRepository GameResultRepository { get; }
        ITeamRepository TeamRepository { get; }

        void SaveChanges();
    }
}