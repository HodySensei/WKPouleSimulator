namespace PouleSimulator
{
    public class Match : IMatch
    {
        public IMatchResult Play(ITeam home, ITeam away)
        {
            MatchResult matchResult = new MatchResult();
            Random random = new Random();

            //Predicting the amount of goals made by both teams
            int homeGoals = CalculateGoals(home);
            int awayGoals = CalculateGoals(away);

            if (homeGoals > awayGoals)
            {
                //Home team wins!
                matchResult.Winner = home;
                matchResult.Loser = away;
            }
            else if (homeGoals < awayGoals)
            {
                //Away team wins!
                matchResult.Winner = away;
                matchResult.Loser = home;
            }
            else
            {
                //It's a draw, so that means we extend the match
                // Adding any goals that were made during extra time
                homeGoals += CalculateGoals(home);
                awayGoals += CalculateGoals(away);


                if (homeGoals > awayGoals)
                {
                    //Home team wins after extra time!
                    matchResult.Winner = home;
                    matchResult.Loser = away;
                }
                else if (homeGoals < awayGoals)
                {
                    //Away team wins after extra time!
                    matchResult.Winner = away;
                    matchResult.Loser = home;
                }
                else
                {
                    //It's a draw even after extra time!
                    matchResult.Draw = true;
                }
            }

            //Updates the status of each team
            home.UpdateStats(homeGoals, awayGoals);
            away.UpdateStats(awayGoals, homeGoals);

            //Sets the results for the match
            matchResult.HomeGoals = homeGoals;
            matchResult.AwayGoals = awayGoals;

            return matchResult;
        }

        int CalculateGoals(ITeam team)
        {
            Random random = new Random();

            int goals = 0;

            // Maximum number of goals a team can score
            int maxGoals = 9;

            for (int i = 0; i < maxGoals; i++)
            {
                int goalChance = ((team.OffensePoints * 35 + team.DefensePoints * 35 + team.TeamPlayPoints * 30 + new Random().Next(0, 100)) / 100);

                // Decrease probability for each goal already scored
                int scoreProbability = goalChance - (i * 10);

                if (random.Next(0,100) < scoreProbability)
                {
                    goals++;
                }
            }

            return goals;
        }
    }
}
