using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public interface ITeam
    {
        int ID { get; set; }
        string Name { get; set; }
        int OffensePoints { get; set; }
        int DefensePoints { get; set; }
        int TeamPlayPoints { get; set; }
        int Played { get; set; }
        int Win { get; set; }
        int Draw { get; set; }
        int Loss { get; set; }
        int For { get; set; }
        int Against { get; set; }
        int Difference { get; }
        int Points { get; set; }
        void UpdateStats(int goalsMade, int goalsTaken);
    }
}
