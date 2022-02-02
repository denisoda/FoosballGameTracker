using FoosballGameServices;
using FoosballGameServices.Interfaces;
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
        private readonly IGameArchiveService _gameArchiveService;
        private readonly IGameTrackingService _gameTrackingService;

        public FoosbalGameArchive(IGameArchiveService gameArchiveService, IGameTrackingService gameTrackingService)
        {
            _gameArchiveService = gameArchiveService;
            _gameTrackingService = gameTrackingService;
        }

        [HttpGet]
        public async Task<ActionResult> GameResults(DateTime statingFromTheDate)
        {
            var results = await _gameArchiveService.GetGameResult(statingFromTheDate, DateTime.Now);
            return Ok(results);
        }

        [HttpGet]
        public async Task<ActionResult> GameResult(Guid gameId)
        {
            if (!await _gameTrackingService.IsGameFinished(gameId))
                return BadRequest("The game is still in progress");
            
            var result =  await _gameArchiveService.GetGameResult(gameId);

            return Ok(result);
        }
    }
}
