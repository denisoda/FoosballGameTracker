using FoosballGameServices.Interfaces;
using FoosballGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoosballGameServices.Services
{
    class GameTrackingService : IGameTrackingService
    {
        private readonly IGameRepository _gameRepository;

        public GameTrackingService(IGameRepository gameTrackingRepository)
        {
            _gameRepository = gameTrackingRepository;
        }

        public Task<Guid> CreateGame(string aTeamName, string bTeamName)
        {
            _gameRepository.GetGameResult(aTeamName, bTeamName);

            return _gameRepository.AddGame(aTeamName, bTeamName);
        }

        public async Task AddGoalToTheTeam(Guid teamId, Team scoredTeam)
        {
            if (await IsGameFinished(teamId))
                throw new ArgumentException("The game is already finnished");

            var gameResult = await GetGameResult(teamId);


            switch (scoredTeam)
            {
                case Team.A:
                    {
                        if (gameResult.SetResults.LastOrDefault().ATeamGoals == 9) // should be moved somewhere else not hardcoded
                            await _gameRepository.AddGoal(teamId, gameResult.ATeamName);
                        await _gameRepository.AddNewSet(gameResult.GameId);
                    }
                    break;
                case Team.B:
                    {
                        if (gameResult.SetResults.LastOrDefault().BTeamGoals == 9)
                            await _gameRepository.AddGoal(teamId, gameResult.BTeamName);
                        await _gameRepository.AddNewSet(gameResult.GameId);
                    }
                    break;
                default:
                    break;
            }
        }

        public async Task<bool> IsGameFinished(Guid gameId)
        {
            var gameResult = await GetGameResult(gameId);

            return gameResult.IsGameFinished;
        }

        public async Task<GameResult> GetGameResult(Guid gameId)
        {
            return await _gameRepository.GetGameResult(gameId);
        }
    }
}
