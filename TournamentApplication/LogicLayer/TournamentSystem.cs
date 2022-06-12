using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public abstract class TournamentSystem
    {

        protected static User userB = new User("B", "B", "Baa@gmail.com", "B", "Bbbbbb", "B");

        public TournamentSystem( )
        {
        }

        public abstract int CalculateRounds(int n);

        public abstract int CalculateMatches(int n);

        public abstract List<Match> CreateMatchSchedule(Tournament t);

        public abstract override string ToString();
    }
}
