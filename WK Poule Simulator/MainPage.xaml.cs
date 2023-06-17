using PouleSimulator;

namespace WK_Poule_Simulator
{
    public partial class MainPage : ContentPage
    {
        public IServiceProvider ServiceProvider { get; set; }
        public Poule Poule { get; set; } = new Poule();

        public MainPage()
        {
            InitializeComponent();
            var services = new ServiceCollection();
            services.AddTransient<ITeam, Team>();
            services.AddTransient<IMatch, Match>();
            services.AddTransient<IMatchResult, MatchResult>();
            ServiceProvider = services.BuildServiceProvider();
            this.InitTeams();
        }

        private async void StartSimulator_Clicked(object sender, EventArgs e)
        {
            await StartPouleAsync();
            InitTeams();
        }

        private void InitTeams()
        {
            Poule.TeamA = ServiceProvider.GetService<ITeam>();
            Poule.TeamA.Name = "Team A";
            Poule.TeamA.OffensePoints = 6;
            Poule.TeamA.DefensePoints = 3;
            Poule.TeamA.TeamPlayPoints = 2;

            Poule.TeamB = ServiceProvider.GetService<ITeam>();
            Poule.TeamB.Name = "Team B";
            Poule.TeamB.OffensePoints = 4;
            Poule.TeamB.DefensePoints = 5;
            Poule.TeamB.TeamPlayPoints = 4;

            Poule.TeamC = ServiceProvider.GetService<ITeam>();
            Poule.TeamC.Name = "Team C";
            Poule.TeamC.OffensePoints = 9;
            Poule.TeamC.DefensePoints = 1;
            Poule.TeamC.TeamPlayPoints = 3;

            Poule.TeamD = ServiceProvider.GetService<ITeam>();
            Poule.TeamD.Name = "Team D";
            Poule.TeamD.OffensePoints = 2;
            Poule.TeamD.DefensePoints = 5;
            Poule.TeamD.TeamPlayPoints = 3;

            BindingContext = Poule;
        }

        private async Task StartPouleAsync()
        {
            var match = ServiceProvider.GetService<IMatch>();

            var round1 = match.Play(Poule.TeamA, Poule.TeamB);
            var round2 = match.Play(Poule.TeamA, Poule.TeamC);
            var round3 = match.Play(Poule.TeamA, Poule.TeamD);

            var round4 = match.Play(Poule.TeamB, Poule.TeamC);
            var round5 = match.Play(Poule.TeamB, Poule.TeamD);

            var round6 = match.Play(Poule.TeamC, Poule.TeamD);

           await this.FinalizePouleAsync();
        }

        private async Task FinalizePouleAsync()
        {
            List<string> Textu = new List<string>();
            List<ITeam> teams = new List<ITeam>()
            {
                Poule.TeamA,
                Poule.TeamB,
                Poule.TeamC,
                Poule.TeamD,
            };

            teams.Sort(new TeamComparer());

            Textu.Add("Group Standings:");
            Textu.Add("================");
            foreach (ITeam team in teams)
            {
                Textu.Add($"Team: {team.Name}, Wins: {team.Win}, Draws: {team.Draw}, Loses: {team.Loss}, GoalsTaken: {team.For}, GoalsMade: {team.Against}, Difference: {team.Difference}, Points: {team.Points}");
            }

            // Determine the teams advancing to the knockout stage
            List<ITeam> knockoutTeams = teams.GetRange(0, 2); // Top two teams advance

            Textu.Add("\nTeams Advancing to Knockout Stage:");
            Textu.Add("===============================");
            foreach (ITeam team in knockoutTeams)
            {
                Textu.Add($"Team: {team.Name}, Wins: {team.Win}, Draws: {team.Draw}, Loses: {team.Loss}, GoalsTaken: {team.For}, GoalsMade: {team.Against}, Difference: {team.Difference}, Points: {team.Points}");
            }

            await DisplayAlert("Results",string.Join(Environment.NewLine, Textu), "OK");
        }
    }
}