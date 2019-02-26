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
    public class PublicController : ControllerBase
    {
        private readonly WebMessageLogic _webMessage;
        private readonly AutomatedTestingLogic _automated;
        private readonly RDSLogic _rdsLogic;
        private readonly ILogger<PublicController> _logger;

        public PublicController(WebMessageLogic webMessage, AutomatedTestingLogic automated,
            ILogger<PublicController> logger, RDSLogic rdsLogic)
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

        [HttpGet("rds/games/game")]
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

    }
}