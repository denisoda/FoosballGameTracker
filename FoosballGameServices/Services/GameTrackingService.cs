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

        public async Task AddGoalToTheTeam(Guid gameId, Team scoredTeam)
        {
            if (await IsGameFinished(gameId))
                throw new ArgumentException("The game is already finnished");

            var gameResult = await GetCurrentGameResult(gameId);

            switch (scoredTeam)
            {
                case Team.A:
                    {
                        if (gameResult.SetResults.LastOrDefault().ATeamGoals != 9) // should be moved somewhere else not hardcoded and also refactor to avoid repetition 
                        {
                            await _gameRepository.AddGoal(gameId, gameResult.ATeamName);
                        }
                        else
                        {
                            await _gameRepository.AddGoal(gameId, gameResult.ATeamName);
                            await _gameRepository.AddNewSet(gameResult.GameId);
                        }
                    }
                    break;
                case Team.B:
                    {
                        if (gameResult.SetResults.LastOrDefault().BTeamGoals != 9) // should be moved somewhere else not hardcoded and also refactor to avoid repetition 
                        {
                            await _gameRepository.AddGoal(gameId, gameResult.BTeamName);
                        }
                        else
                        {
                            await _gameRepository.AddGoal(gameId, gameResult.BTeamName);
                            await _gameRepository.AddNewSet(gameResult.GameId);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public async Task<bool> IsGameFinished(Guid gameId)
        {
            var gameResult = await GetCurrentGameResult(gameId);

            return gameResult.IsGameFinished;
        }

        public async Task<GameResult> GetCurrentGameResult(Guid gameId)
        {
            if (await IsGameFinished(gameId))
                throw new ArgumentException("The game is already finnished");

            return await _gameRepository.GetGameResult(gameId);
        }
    }
}
