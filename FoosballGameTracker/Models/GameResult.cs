using System.Collections.Generic;

namespace FoosballGameTracker.Models
{
    public class GameResult
    {
        public string ATeamName { get; set; }
        public string BTeamName { get; set; }
        public IList<SetResult> SetResults { get; set; }
        public bool IsGameFinished { get; set; }
    }
}
