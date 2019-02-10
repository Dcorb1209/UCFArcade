using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutomatedTesting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutomatedTestingController : Controller
    {
        private readonly ILogger<AutomatedTestingController> _logger;

        public AutomatedTestingController(ILogger<AutomatedTestingController> logger)
        {
            _logger = logger;
        }


        [HttpGet("basictest")]
        public IActionResult PostAutomatedTest([FromBody] object game)
        {
            try
            {
                string x = AppDomain.CurrentDomain.BaseDirectory;
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500);
            }
        }

        [HttpGet("s3/game")]
        public IActionResult GetGame(string gameName)
        {
            try
            {
                //object x = await _s3Data.ReadObjectDataAsync("arcadegrassproject", "arcade_games", gameName);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(500, e.Message);
            }
        }
    }
}