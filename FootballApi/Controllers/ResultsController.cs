using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FootballApi.Presentation.ViewModels;

namespace FootballApi.Controllers
{
    public class ResultsController : ApiController
    {
        public GameResultViewModel[] Get([FromUri] int id)
        {
            return new GameResultViewModel[0];
        }

        public void Post([FromBody] PostGameResultViewModel viewModel)
        {
            
        }
    }
}
