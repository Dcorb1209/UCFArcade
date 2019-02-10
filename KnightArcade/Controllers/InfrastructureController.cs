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
        private readonly S3Logic _s3;
        private readonly WebMessageLogic _webMessage;
        private readonly AutomatedTestingLogic _automated;
        private readonly RDSLogic _rdsLogic;
        private readonly ILogger<InfrastructureController> _logger;
        private readonly IS3Data _s3Data;

        public InfrastructureController(S3Logic s3, WebMessageLogic webMessage, AutomatedTestingLogic automated,
            ILogger<InfrastructureController> logger, IS3Data s3Data, RDSLogic rdsLogic)
        {
            _webMessage = webMessage;
            _automated = automated;
            _logger = logger;
            _s3 = s3;
            _s3Data = s3Data;
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

        [HttpGet("s3/allgameslist")]
        public IActionResult GetAllGamesList()
        {
            try
            {
                return Ok("Arcade GRASS: Get All Games List.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("s3/game")]
        public async Task<IActionResult> GetGame(string gameName)
        {
            try
            {
                object x = await _s3Data.ReadObjectDataAsync("arcadegrassproject", "arcade_games", gameName);
                return Ok(x);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("s3/gamereport")]
        public IActionResult GetGameReport(string gameName)
        {
            try
            {
                return Ok("Arcade GRASS: Get Game Report " + gameName);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("s3/gamereport")]
        public IActionResult PostGameReportToS3([FromBody] object gameReport)
        {
            try
            {
                return Ok("Arcade GRASS: Post Game Report To S3.");
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