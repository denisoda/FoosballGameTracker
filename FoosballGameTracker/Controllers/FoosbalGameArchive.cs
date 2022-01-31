using FoosballGameServices;
using FoosballGameTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballGameTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoosbalGameArchive : ControllerBase
    {
        private IGameTrackingService _gameTrackingService;

        public FoosbalGameArchive(IGameTrackingService gameTrackingService)
        {
            _gameTrackingService = gameTrackingService;
        }

        [HttpGet]
        public async Task<ActionResult> GameResults(DataType statingFromTheDate)
        {
            //get from repository via service
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GameResult(Guid gameId)
        {
            if (!await _gameTrackingService.IsGameFinished(gameId))
                return BadRequest("The game is still in progress");
            //get from repository via service
            return Ok();
        }
    }
}
