using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FootballApi.Presentation.ViewModels;

namespace FootballApi.Controllers
{
    public class TableController : ApiController
    {
        public TableRowViewModel[] Get()
        {
            return new TableRowViewModel[0];
        }
    }
}
