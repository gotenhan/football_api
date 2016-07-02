using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpressMapper.Extensions;
using FootballApi.CrossCuting;
using FootballApi.Domain.Models;
using FootballApi.Domain.Services;
using FootballApi.Presentation.ViewModels;

namespace FootballApi.Controllers
{
    public class TableController : ApiController
    {
        private readonly ITableService _tableService;
        private readonly object _mapper;

        public TableController(ITableService tableService, IMapper<IEnumerable<TableRow>, IEnumerable<TableRowViewModel>> mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        public IHttpActionResult Get()
        {
            var table = _tableService.GetTable();
            var tableViewModel = _mapper.Map(table);
            return Ok(tableViewModel);
        }
    }
}
