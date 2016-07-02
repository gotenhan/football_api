using System.Collections.Generic;
using FootballApi.Domain.Models;

namespace FootballApi.Domain.Repositories
{
    public interface ITeamRepository
    {
        List<Team> GetAll();
        Team Get(string name);
        void Store(Team team);
    }
}