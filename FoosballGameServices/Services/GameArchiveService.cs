using FoosballGameServices.Interfaces;
using FoosballGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoosballGameServices.Services
{
    class GameArchiveService : IGameArchiveService
    {
        private readonly IGameRepository _gameRepository;

        public GameArchiveService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<IEnumerable<GameResult>> GetGameResult(DateTime startDate, DateTime finishDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameResult>> GetGameResult(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
