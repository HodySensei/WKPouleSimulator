using PouleSimulator;

namespace WK_Poule_Simulator
{
    public partial class MainPage : ContentPage
    {
        private IServiceProvider _serviceProvider;
        private Poule _poule;
        private int _matchesPlayed;

        public IServiceProvider ServiceProvider { get => _serviceProvider; set => _serviceProvider = value; }
        public Poule Poule { get => _poule; set => _poule = value; }
        public int MatchesPlayed { get => _matchesPlayed; set => _matchesPlayed = value; }

        public MainPage()
        {
            InitializeComponent();

            //Initialize Simulator at startup
            var services = new ServiceCollection();
            services.AddTransient<ITeam, Team>();
            services.AddTransient<IMatch, Match>();
            services.AddTransient<IMatchResult, MatchResult>(); 
            Poule = new Poule();
            ServiceProvider = services.BuildServiceProvider();
            this.Reset();
        }

        private async void btnStartMatch_Clicked(object sender, EventArgs e)
        {
            //Initializing the objects needed to start a match.
            var button = (Button)sender;
            var matchup = (MatchUp)button.BindingContext;
            var match = ServiceProvider.GetService<IMatch>();
            var result = match.Play(matchup.Home, matchup.Away);


            //Match results will be updated and the resulting numbers are displayed on screen
            //this matchup will not be able to be played until the Poule is reset
            button.IsEnabled = false;
            button.BackgroundColor = new Color(255, 0, 0);
            button.Text = "Match played!";
            button.Opacity = 0.15;
            matchup.OutputLabel.Text = $"{result.HomeGoals} - {result.AwayGoals}";

            //Display a message that says who won or if its a draw
            if(result.Draw)
            await DisplayAlert("Result", "Its a Draw!", "OK");
            else
                await DisplayAlert("Result", $"The winner is {result.Winner.Name}!", "OK");

            //this chunk checks if there are 6 matches played
            MatchesPlayed++;
            if (MatchesPlayed == 6)
            {
                //Turn on the Finalize Poule button to determine the teams for knockout stage
                btnFinalizePoule.BackgroundColor = new Color(0, 255, 255);
                btnFinalizePoule.IsEnabled = true;
            }
        }

        private void btnFinalizePoule_Clicked(object sender, EventArgs e)
        {
            this.FinalizePoule();
        }

        private void btnResetPoule_Clicked(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void InitMatches()
        {
            //Setting every respective property of a match to a matchup object
            //Binding it to its respective button so that it has data on the go
            btnStartMatch1.BindingContext = new MatchUp() { Home = Poule.TeamA, Away = Poule.TeamB, OutputLabel = lblMatch1Stance };
            btnStartMatch2.BindingContext = new MatchUp() { Home = Poule.TeamA, Away = Poule.TeamC, OutputLabel = lblMatch2Stance };
            btnStartMatch3.BindingContext = new MatchUp() { Home = Poule.TeamA, Away = Poule.TeamD, OutputLabel = lblMatch3Stance };
            btnStartMatch4.BindingContext = new MatchUp() { Home = Poule.TeamB, Away = Poule.TeamC, OutputLabel = lblMatch4Stance };
            btnStartMatch5.BindingContext = new MatchUp() { Home = Poule.TeamB, Away = Poule.TeamD, OutputLabel = lblMatch5Stance };
            btnStartMatch6.BindingContext = new MatchUp() { Home = Poule.TeamC, Away = Poule.TeamD, OutputLabel = lblMatch6Stance };
        }

        private void InitTeams()
        {
            //Initializing teams and their stats, these can be dynamically changed on the simulator

            Poule.TeamA = ServiceProvider.GetService<ITeam>();
            Poule.TeamA.Name = "Team A";
            Poule.TeamA.OffensePoints = 61;
            Poule.TeamA.DefensePoints = 83;
            Poule.TeamA.TeamPlayPoints = 72;

            Poule.TeamB = ServiceProvider.GetService<ITeam>();
            Poule.TeamB.Name = "Team B";
            Poule.TeamB.OffensePoints = 74;
            Poule.TeamB.DefensePoints = 65;
            Poule.TeamB.TeamPlayPoints = 84;

            Poule.TeamC = ServiceProvider.GetService<ITeam>();
            Poule.TeamC.Name = "Team C";
            Poule.TeamC.OffensePoints = 69;
            Poule.TeamC.DefensePoints = 61;
            Poule.TeamC.TeamPlayPoints = 93;

            Poule.TeamD = ServiceProvider.GetService<ITeam>();
            Poule.TeamD.Name = "Team D";
            Poule.TeamD.OffensePoints = 52;
            Poule.TeamD.DefensePoints = 85;
            Poule.TeamD.TeamPlayPoints = 83;

            BindingContext = Poule;
        }

        private void FinalizePoule()
        {
            List<ITeam> teams = new List<ITeam>()
            {
                Poule.TeamA,
                Poule.TeamB,
                Poule.TeamC,
                Poule.TeamD,
            };

            // Teams get sorted
            teams.Sort(new TeamComparer());

            // Determine the teams advancing to the knockout stage
            List<ITeam> knockoutTeams = teams.GetRange(0, 2);

            // Top two teams advance
            foreach (ITeam team in knockoutTeams)
            {
                //Teams that advance will be colored turqouise
                if (team.Name == "Team A")
                    TeamA.BackgroundColor = new Color(0, 249, 216);
                else if (team.Name == "Team B")
                    TeamB.BackgroundColor = new Color(0, 249, 216);
                else if (team.Name == "Team C")
                    TeamC.BackgroundColor = new Color(0, 249, 216);
                else if (team.Name == "Team D")
                    TeamD.BackgroundColor = new Color(0, 249, 216);
            }

            //Poule already finalized, so this button goes off until the poule is reset
            btnFinalizePoule.IsEnabled = false;
            btnFinalizePoule.BackgroundColor = new Color(122,122,122);
        }

        private void Reset()
        {
            //Simulator Resets to zero.
            MatchesPlayed = 0;
            btnStartMatch1.IsEnabled = btnStartMatch2.IsEnabled = btnStartMatch3.IsEnabled = btnStartMatch4.IsEnabled = btnStartMatch5.IsEnabled = btnStartMatch6.IsEnabled = true;
            btnStartMatch1.Opacity = btnStartMatch2.Opacity = btnStartMatch3.Opacity = btnStartMatch4.Opacity = btnStartMatch5.Opacity = btnStartMatch6.Opacity = 1;
            btnStartMatch1.BackgroundColor = btnStartMatch2.BackgroundColor = btnStartMatch3.BackgroundColor = btnStartMatch4.BackgroundColor = btnStartMatch5.BackgroundColor = btnStartMatch6.BackgroundColor = Color.FromHex("#55FF00");
            btnStartMatch1.Text = btnStartMatch2.Text = btnStartMatch3.Text = btnStartMatch4.Text = btnStartMatch5.Text = btnStartMatch6.Text = "Start Match";
            lblMatch1Stance.Text = lblMatch2Stance.Text = lblMatch3Stance.Text = lblMatch4Stance.Text = lblMatch5Stance.Text = lblMatch6Stance.Text = "0 - 0";
            TeamA.BackgroundColor = TeamB.BackgroundColor = TeamC.BackgroundColor = TeamD.BackgroundColor = Color.FromHex("#80CC00");
            this.InitTeams();
            this.InitMatches();
        }
    }
}