using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;

namespace FootballApi.Data.Repositories
{
    public class TeamRepository: ITeamRepository
    {
        private readonly FootballApiContext _footballApiContext;

        public TeamRepository(FootballApiContext footballApiContext)
        {
            _footballApiContext = footballApiContext;
        }

        public Team Get(string name)
        {
            var teams = _footballApiContext.Teams.ToArray();
            var team = _footballApiContext.Teams.Find(name);
            return team;
        }

        public void Store(Team team)
        {
            var loaded = _footballApiContext.Teams.Find(team.Name);
            if(loaded == null)
            {
                _footballApiContext.Teams.Add(team);
            }
            else
            {
                _footballApiContext.Teams.Attach(team);
                _footballApiContext.Entry(team).State = EntityState.Modified;
            }

            _footballApiContext.SaveChanges();
        }
    }
}
