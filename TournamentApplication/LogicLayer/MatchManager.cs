using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MatchManager : IMatchManager
    {
        IMatchDB<Match> db;
        public MatchManager(IMatchDB<Match> db)
        {
            this.db = db;
        }
        public void AddMatch(List<Match> matches, Tournament t)
        {
            db.AddMatch(matches, t);
        }

        public void GetMatchesForTournament(Tournament t)
        {
            db.GetMatches(t);
        }
        public void SetScore(Match m, Tournament t)
        {
            db.SetScore(m, t);
        }

    }
}
