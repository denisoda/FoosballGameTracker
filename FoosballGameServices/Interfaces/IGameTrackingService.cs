using FoosballGameTracker.Models;
using System;
using System.Threading.Tasks;

namespace FoosballGameServices
{
    public interface IGameTrackingService
    {
        Task<Guid> CreateGame(string aTeamName, string bTeamName);
        Task AddGoalToTheTeam(Guid gameId, Team teamName);
        Task<bool> IsGameFinished(Guid gameId);
        Task<GameResult> GetCurrentGameResult(Guid gameId);
    }
}
