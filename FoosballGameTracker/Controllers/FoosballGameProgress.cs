using FoosballGameServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoosballGameTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoosballGameProgress : ControllerBase
    {
        private IGameTrackingService _gameTrackingService;

        public FoosballGameProgress(IGameTrackingService gameTrackingService)
        {
            _gameTrackingService = gameTrackingService;
        }

        [HttpPost]
        public async Task<ActionResult> Game(string aTeamName, string bTeamName)
        {
            if (string.IsNullOrEmpty(aTeamName) && string.IsNullOrEmpty(bTeamName))
                return BadRequest("Team name is null or empty");

            var gameId = await _gameTrackingService.CreateGame(aTeamName, bTeamName);

            return Ok(gameId);
        }

        [HttpPost]
        public async Task<ActionResult> Goal(Guid gameId, Team teamScored)
        {
            if (await _gameTrackingService.IsGameFinished(gameId))
                return BadRequest("Game is already finished");

            await _gameTrackingService.AddGoalToTheTeam(gameId, teamScored); //map to service type

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> CurrentStatus(Guid gameId)
        {
            if (await _gameTrackingService.IsGameFinished(gameId))
                return BadRequest("Game is already finished");

            var gameResult = await _gameTrackingService.GetCurrentGameResult(gameId);

            return Ok(gameResult);
        }

    }
}
