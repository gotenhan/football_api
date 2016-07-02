using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressMapper;
using FootballApi.CrossCuting;
using FootballApi.Domain;
using FootballApi.Domain.Models;
using FootballApi.Presentation.ViewModels;

namespace FootballApi.Presentation.Mappers
{
    public class GameResultMapperRegistration: IMapperRegistration
    {
        public GameResultMapperRegistration()
        {
            Mapper.Register<PostGameResultViewModel, GameResult>()
                .Member(gr => gr.HomeTeamName, pgrvm => pgrvm.HomeTeam)
                .Member(gr => gr.AwayTeamName, pgrvm => pgrvm.AwayTeam)
                .Ignore(gr => gr.HomeTeam)
                .Ignore(gr => gr.AwayTeam);
            Mapper.Register<GameResult, GameResultViewModel>()
                .Member(grvm => grvm.HomeTeam, gr => gr.HomeTeamName)
                .Member(grvm => grvm.AwayTeam, gr => gr.AwayTeamName);
        }
    }
}
