using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public interface IMatchResult
    {
        ITeam Loser { get; }
        ITeam Winner { get; }
        bool Draw { get; }
        int AwayGoals { get; set; }
        int HomeGoals { get; set; }
    }
}
