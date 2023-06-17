using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public class MatchResult: IMatchResult
    {
        public ITeam Loser { get; set; }
        public ITeam Winner { get; set; }
        public bool Draw { get; set; }
        public TimeSpan Time { get; set; }
        public bool Extended { get => Time.TotalMinutes > 90; }
    }
}
