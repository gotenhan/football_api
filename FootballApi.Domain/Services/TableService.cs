using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballApi.CrossCuting;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;

namespace FootballApi.Domain.Services
{
    public interface ITableService
    {
        List<TableRow> GetTable();
    }

    public class TableService: ITableService
    {
        private readonly ITeamRepository _teamsRepository;
        private readonly IMapper<Team, TableRow> _mapper;

        public TableService(ITeamRepository teamsRepository, IMapper<Team, TableRow> mapper)
        {
            _teamsRepository = teamsRepository;
            _mapper = mapper;
        }

        public List<TableRow> GetTable()
        {
            return _teamsRepository.GetAll()
                .OrderByDescending(t => t.Score)
                .ThenBy(t => t.GamesPlayed)
                .ThenBy(t => t.Name)
                .Select(Map).ToList();
        }

        private TableRow Map(Team team, int index)
        {
            var tableRow = _mapper.Map(team);
            tableRow.Position = index + 1;
            return tableRow;
        }
    }
}