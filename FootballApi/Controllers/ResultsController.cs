using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FootballApi.CrossCuting;
using FootballApi.Domain;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;
using FootballApi.Domain.Services;
using FootballApi.Presentation.ViewModels;

namespace FootballApi.Controllers
{
    public class ResultsController : ApiController
    {
        private readonly IMapper<PostGameResultViewModel, GameResult> _postGameResultMapper;
        private readonly IMapper<IEnumerable<GameResult>, IEnumerable<GameResultViewModel>> _gameResultMapper;
        private readonly IAddGameResultService _addGameResultsService;
        private readonly IGameResultRepository _gameResultRepository;

        public ResultsController(IAddGameResultService addGameResultsService, IGameResultRepository gameResultRepository, IMapper<PostGameResultViewModel, GameResult> postGameResultMapper,
            IMapper<IEnumerable<GameResult>, IEnumerable<GameResultViewModel>> gameResultMapper)
        {
            _postGameResultMapper = postGameResultMapper;
            _gameResultMapper = gameResultMapper;
            _addGameResultsService = addGameResultsService;
            _gameResultRepository = gameResultRepository;
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            if (id < 1 || id > 38)
                return BadRequest("Week id must be in range 1-38");

            var results = _gameResultRepository.GetForGameWeek(id);
            var resultsViewModel = _gameResultMapper.Map(results);
            return Ok(resultsViewModel);
        }

        public IHttpActionResult Post([FromBody] PostGameResultViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var gameResult = _postGameResultMapper.Map(viewModel);
                _addGameResultsService.Add(gameResult);

                return Ok(gameResult.Id);
            }
            catch (FootballApiException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
