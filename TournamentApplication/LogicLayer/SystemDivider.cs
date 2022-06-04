using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SystemDivider
    {
        public TournamentSystem DivideTournamentSystems(string systemName)
        {
            if (systemName == TournamentNames.RoundRobin)
            {
                TournamentSystem ts = new RoundRobin();
                return ts;
            }
            else if (systemName == TournamentNames.DoubleRoundRobin)
            {
                TournamentSystem ts = new DoubleRoundRobin();
                return ts;
            }

            throw new MyException("Unsupported tournament type");
        }
    }
}
