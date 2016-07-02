using FootballApi.CrossCuting;
using FootballApi.Domain.Models;

namespace FootballApi.Domain.Mappers
{
    public class TeamToTableRowMapperRegistration: IMapperRegistration
    {
        public TeamToTableRowMapperRegistration()
        {
            ExpressMapper.Mapper.Register<Team, TableRow>()
                .Member(tr => tr.GoalsFor, t => t.GoalsScored)
                .Member(tr => tr.GoalsAgainst, t => t.GoalsLost)
                .Member(tr => tr.Points, t => t.Score)
                .Member(tr => tr.Team, t => t.Name)
                .Member(tr => tr.GoalDifference, t => t.GoalsDifference);
        }
    }
}