namespace PouleSimulator
{
    public interface IPoule
    {
        ITeam TeamA { get; set; }
        ITeam TeamB { get; set; }
        ITeam TeamC { get; set; }
        ITeam TeamD { get; set; }
    }
}