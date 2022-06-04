using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public abstract class TournamentSystem
    {

        public int Rounds { get; set; }
        public int Matches { get;set; }

        protected TournamentSystem( )
        {
        }

        public abstract int CalculateRounds(int n);

        public abstract int CalculateMatches(int n);

        public abstract List<Match> CreateMatchSchedule(List<User> competitors, Tournament t);

        public abstract override string ToString();
    }
}
