using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightArcade.Infrastructure.Data;
using KnightArcade.Infrastructure.Data.Interface;
using KnightArcade.Infrastructure.Logic;
using KnightArcade.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnightArcade.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InfrastructureController : ControllerBase
    {
        private readonly WebMessageLogic _webMessage;
        private readonly AutomatedTestingLogic _automated;
        private readonly RDSLogic _rdsLogic;
        private readonly ILogger<InfrastructureController> _logger;

        public InfrastructureController(WebMessageLogic webMessage, AutomatedTestingLogic automated,
            ILogger<InfrastructureController> logger, RDSLogic rdsLogic)
        {
            _webMessage = webMessage;
            _automated = automated;
            _logger = logger;
            _rdsLogic = rdsLogic;
        }

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            try
            {
                return Ok("UCF Spring 2019 Senior Design Arcade GRASS project.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("rds/gamesdata")]
        public IActionResult GetGamesData(int gameId)
        {
            try
            {
                return Ok(_rdsLogic.GetGames(gameId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("rds/allgamesdata")]
        public IActionResult GetAllGamesData()
        {
            try
            {
                return Ok(_rdsLogic.GetAllGames());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("rds/gamesdata")]
        public IActionResult PostGamesData([FromBody] Games games)
        {
            try
            {
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

        ///
        [HttpPost("game")]
        public IActionResult PostGameForTesting([FromBody] object gameFile)
        {
            try
            {
                return Ok("Arcade GRASS: Post Game For Testing.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

        [HttpPost("arcademachine")]
        public IActionResult PostGameToArcadeMachine([FromBody] object gameFile)
        {
            try
            {
                return Ok("Arcade GRASS: Post Game To Arcade Machine");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

        [HttpPost("arcademachinefroms3")]
        public IActionResult PostGameToArcadeMachine(string gameName)
        {
            try
            {
                return Ok("Arcade GRASS: Post Game to Arcade Machine From S3 " + gameName);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }
    }
}