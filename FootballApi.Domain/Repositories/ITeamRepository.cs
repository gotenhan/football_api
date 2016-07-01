using FootballApi.Domain.Models;

namespace FootballApi.Domain.Repositories
{
    public interface ITeamRepository
    {
        Team Get(string name);
        void Store(Team team);
    }
}