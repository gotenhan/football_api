using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;

namespace FootballApi.Data.Repositories
{
    public class GameResultRepository: IGameResultRepository
    {
        private readonly FootballApiContext _footballApiContext;

        public GameResultRepository(FootballApiContext footballApiContext)
        {
            _footballApiContext = footballApiContext;
        }

        public List<GameResult> GetAll()
        {
            return _footballApiContext.GameResults.ToList();
        }

        public List<GameResult> GetForGameWeek(int gameWeek)
        {
            return _footballApiContext.GameResults.Where(gr => gr.GameWeek == gameWeek).ToList();
        }

        public void Store(GameResult gameResult)
        {
            if (gameResult.Id.HasValue)
            {
                throw new ArgumentException("Updating game result is not supported", nameof(gameResult));
            }

            var homeTeam = _footballApiContext.Teams.Find(gameResult.HomeTeam);
            var awayTeam = _footballApiContext.Teams.Find(gameResult.AwayTeam);

            if (homeTeam == null) throw new ArgumentException("Home team must exist in database");
            if (awayTeam == null) throw new ArgumentException("Away team must exist in database");

            // use stored teams, changing teams through gameResult repo should not be possible
            gameResult.HomeTeam = homeTeam;
            gameResult.AwayTeam = awayTeam;

            _footballApiContext.GameResults.Add(gameResult);

            _footballApiContext.SaveChanges();
        }
    }
}
