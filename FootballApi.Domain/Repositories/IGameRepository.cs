using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Domain.Models;

namespace FootballApi.Domain.Repositories
{
    interface IGameRepository
    {
        List<Game> GetAll();
        List<Game> GetForGameWeek(int gameWeek);
    }
}
