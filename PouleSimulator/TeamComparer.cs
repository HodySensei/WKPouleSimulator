using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public class TeamComparer : IComparer<ITeam>
    {
        public int Compare(ITeam x, ITeam y)
        {
            // First, compare based on Points
            int pointsComparison = y.Points.CompareTo(x.Points);

            if (pointsComparison != 0)
            {
                // If Points are different, return the comparison result
                return pointsComparison;
            }
            else
            {
                pointsComparison = y.Difference.CompareTo(x.Difference);

                if (pointsComparison != 0)
                {
                    // If Points are different, return the comparison result
                    return pointsComparison;
                }
                else
                {
                    pointsComparison = y.For.CompareTo(x.For);

                    if (pointsComparison != 0)
                    {
                        // If Points are different, return the comparison result
                        return pointsComparison;
                    }
                    else
                    {
                        return y.Against.CompareTo(x.Against);
                    }
                }
            }
        }
    }
}
