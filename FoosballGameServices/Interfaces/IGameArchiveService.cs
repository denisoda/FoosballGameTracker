using FoosballGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoosballGameServices.Interfaces
{
    public interface IGameArchiveService
    {
        Task<IEnumerable<GameResult>> GetGameResult(DateTime startDate, DateTime finishDate);
        Task<IEnumerable<GameResult>> GetGameResult(Guid gameId);
    }
}
