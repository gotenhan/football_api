using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using FootballApi.CrossCuting;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;

namespace FootballApi.Domain.Services
{
    public interface IAddGameResultService
    {
        void Add(GameResult gameResult);
    }

    public class UnknownTeamException : FootballApiException
    {
        public UnknownTeamException(string teamName) : base($"Team {teamName} does not exist")
        {
        }
    };

    public class AddGameResultService: IAddGameResultService
    {
        private readonly IAddGameResultUnitOfWork _unitOfWork;

        public AddGameResultService(IAddGameResultUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(GameResult gameResult)
        {
            var homeTeam = _unitOfWork.TeamRepository.Get(gameResult.HomeTeamName);
            var awayTeam = _unitOfWork.TeamRepository.Get(gameResult.AwayTeamName);

            if (homeTeam == null) throw new UnknownTeamException(gameResult.HomeTeamName);
            if (awayTeam == null) throw new UnknownTeamException(gameResult.AwayTeamName);

            UpdateGamesPlayed(homeTeam, awayTeam);
            UpdateGoals(gameResult, homeTeam, awayTeam);

            UpdatePoints(gameResult, homeTeam, awayTeam);
        }

        private static void UpdatePoints(GameResult gameResult, Team homeTeam, Team awayTeam)
        {
            if (gameResult.AwayGoals == gameResult.HomeGoals)
            {
                homeTeam.Score++;
                awayTeam.Score++;
            }
            else
            {
                var winningTeam = gameResult.HomeGoals > gameResult.AwayGoals ? homeTeam : awayTeam;
                winningTeam.Score++;
            }
        }

        private static void UpdateGoals(GameResult gameResult, Team homeTeam, Team awayTeam)
        {
            homeTeam.GoalsScored += gameResult.HomeGoals;
            awayTeam.GoalsScored += gameResult.AwayGoals;
            homeTeam.GoalsLost += gameResult.AwayGoals;
            awayTeam.GoalsLost += gameResult.HomeGoals;
        }

        private static void UpdateGamesPlayed(Team homeTeam, Team awayTeam)
        {
            homeTeam.GamesPlayed++;
            awayTeam.GamesPlayed++;
        }
    }
}