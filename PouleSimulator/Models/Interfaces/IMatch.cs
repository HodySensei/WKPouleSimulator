using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouleSimulator
{
    public interface IMatch
    {
        IMatchResult Play(ITeam home, ITeam away);
    }
}
