using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightArcade.Infrastructure.Data;
using KnightArcade.Infrastructure.Data.Interface;
using KnightArcade.Infrastructure.Logic;
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
        private readonly ILogger<InfrastructureController> _logger;
        private readonly IS3Data _s3Data;

        public InfrastructureController(S3Logic s3, WebMessageLogic webMessage, AutomatedTestingLogic automated,
            ILogger<InfrastructureController> logger, IS3Data s3Data)
        {
            _webMessage = webMessage;
            _automated = automated;
            _logger = logger;
            _s3 = s3;
            _s3Data = s3Data;
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
                return StatusCode(500);
            }
        }

        [HttpGet("allgameslist")]
        public IActionResult GetAllGamesList()
        {
            try
            {
                return Ok("Arcade GRASS: Get All Games List.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

        [HttpGet("game")]
        public async Task<IActionResult> GetGame(string gameName)
        {
            try
            {
                object x = await _s3Data.ReadObjectDataAsync("arcadegrassproject", "arcade_games", "AlienDefense5(Final).zip");
                //return Ok("Arcade GRASS: Get Game " + gameName);
                return Ok(x);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

        [HttpGet("gamereport")]
        public IActionResult GetGameReport(string gameName)
        {
            try
            {
                return Ok("Arcade GRASS: Get Game Report " + gameName);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

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

        [HttpPost("gamereport")]
        public IActionResult PostGameReportToS3([FromBody] object gameReport)
        {
            try
            {
                return Ok("Arcade GRASS: Post Game Report To S3.");
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