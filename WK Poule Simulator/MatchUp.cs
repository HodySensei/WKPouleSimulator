using PouleSimulator;

namespace WK_Poule_Simulator
{
    public class MatchUp
    {
        public ITeam _home;
        public ITeam _away;
        public Label _outputLabel;

        public ITeam Home { get => _home; set => _home = value; }
        public ITeam Away { get => _away; set => _away = value; }
        public Label OutputLabel { get => _outputLabel; set => _outputLabel = value; }
    }
}
