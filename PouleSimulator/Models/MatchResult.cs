namespace PouleSimulator
{
    public class MatchResult: IMatchResult
    {
        public ITeam Loser { get; set; }
        public ITeam Winner { get; set; }
        public bool Draw { get; set; }
        public int AwayGoals { get; set; }
        public int HomeGoals { get; set; }
    }
}
