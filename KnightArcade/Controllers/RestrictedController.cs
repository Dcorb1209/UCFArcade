using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightArcade.Infrastructure.Logic;
using KnightArcade.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnightArcade.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestrictedController : ControllerBase
    {
        private readonly WebMessageLogic _webMessage;
        private readonly AutomatedTestingLogic _automated;
        private readonly RDSLogic _rdsLogic;
        private readonly ILogger<PublicController> _logger;

        public RestrictedController(WebMessageLogic webMessage, AutomatedTestingLogic automated,
            ILogger<PublicController> logger, RDSLogic rdsLogic)
        {
            _webMessage = webMessage;
            _automated = automated;
            _logger = logger;
            _rdsLogic = rdsLogic;
        }

        [HttpGet("rds/games/postgame")]
        public IActionResult PostGamesData()
        {
            try
            {
                Games games = new Games()
                {
                    GameControls = "asasdd",
                    GameCreatorId = 1212,
                    GameCreatorname = "yo mama",
                    GameDescription = "dayummm",
                    GameGenres = "good game",
                    GameImage0 = "this is a url",
                    GameImage1 = "this is a url too",
                    GameName = "GoodGame69",
                    GamePath = "not a path",
                    GameVideolink = "https://www.youtube.com/user/PewDiePie",
                    GameId = null
                };
                return Ok(_rdsLogic.PostGames(games));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("rds/gamesdata")]
        public IActionResult PutGamesData([FromBody] Games games)
        {
            try
            {
                return Ok(_rdsLogic.PutGames(games));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("rds/gamesdata")]
        public IActionResult DeleteGamesData(int gameId)
        {
            try
            {
                return Ok(_rdsLogic.DeleteGames(gameId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }
    }
}