namespace PouleSimulator
{
    public class MatchResult: IMatchResult
    {
        private ITeam _loser;
        private ITeam _winner;
        private bool _draw;
        private int _awayGoals;
        private int _homeGoals;

        public ITeam Loser { get => _loser; set => _loser = value; }
        public ITeam Winner { get => _winner; set => _winner = value; }
        public bool Draw { get => _draw; set => _draw = value; }
        public int AwayGoals { get => _awayGoals; set => _awayGoals = value; }
        public int HomeGoals { get => _homeGoals; set => _homeGoals = value; }
    }
}
