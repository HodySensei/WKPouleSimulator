using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public class Match : IMatch
    {
        public IMatchResult Play(ITeam home, ITeam away)
        {
            MatchResult matchResult = new MatchResult();
            Random random = new Random();
            int matchDuration = 90;
            int extendedTime = 0;

            int homeGoals = CalculateGoals(home);
            int awayGoals = CalculateGoals(away);
            Console.WriteLine($"Home team goals: {homeGoals}");
            Console.WriteLine($"Away team goals: {awayGoals}");

            if (homeGoals > awayGoals)
            {
                Console.WriteLine("Home team wins!");
                matchResult.Winner = home;
                matchResult.Loser = away;
            }
            else if (homeGoals < awayGoals)
            {
                Console.WriteLine("Away team wins!");
                matchResult.Winner = away;
                matchResult.Loser = home;
            }
            else
            {
                Console.WriteLine("It's a draw!");
                
                extendedTime = random.Next(3, 11);
                Console.WriteLine($"Extra time: {extendedTime} minutes");

                homeGoals += CalculateGoals(home);
                awayGoals += CalculateGoals(away);
                Console.WriteLine($"Home team goals (after extra time): {homeGoals}");
                Console.WriteLine($"Away team goals (after extra time): {awayGoals}");


                if (homeGoals > awayGoals)
                {
                    Console.WriteLine("Home team wins after extra time!");
                    matchResult.Winner = home;
                    matchResult.Loser = away;
                }
                else if (homeGoals < awayGoals)
                {
                    Console.WriteLine("Away team wins after extra time!");
                    matchResult.Winner = away;
                    matchResult.Loser = home;
                }
                else
                {
                    Console.WriteLine("It's a draw even after extra time!");
                    matchResult.Draw = true;
                }
            }

            matchResult.Time = TimeSpan.FromMinutes(matchDuration + extendedTime);
            Console.WriteLine($"Total duration: {matchResult.Time.TotalMinutes} minutes");

            home.UpdateStats(homeGoals, awayGoals);
            away.UpdateStats(awayGoals, homeGoals);

            return matchResult;
        }

        int CalculateGoals(ITeam team)
        {
            Random random = new Random();

            int goals = 0;
            int maxGoals = 5; // Maximum number of goals a team can score

            for (int i = 0; i < maxGoals; i++)
            {
                int goalChance = ((team.OffensePoints * 35 + team.DefensePoints * 35 + team.TeamPlayPoints * 30 * new Random().Next(0, 5)) / 100);
                int scoreProbability = goalChance - (i * 10); // Decrease probability for each goal already scored

                if (random.Next(-150,10) > scoreProbability)
                {
                    goals++;
                }
            }

            return goals;
        }
    }
}
