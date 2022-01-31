using FoosballGameTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace FoosballGameServices.Interfaces
{
    interface IGameRepository
    {
        Task<Guid> AddGame(string aTeamName, string bTeamName);
        Task AddGoal(Guid gameId, string teamName);
        Task<GameResult> GetGameResult(Guid gameId);
        Task<GameResult> GetGameResult(string aTeamName, string bTeamName);
        Task<GameResult> GetGameResult(DataType statingFromTheDate);
        Task AddNewSet(Guid gameId);
    }
}
