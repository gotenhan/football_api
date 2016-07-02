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
    public class TableRowMapperRegistration: IMapperRegistration
    {
        public TableRowMapperRegistration()
        {
            Mapper.Register<TableRow, TableRowViewModel>();
        }
    }
}
