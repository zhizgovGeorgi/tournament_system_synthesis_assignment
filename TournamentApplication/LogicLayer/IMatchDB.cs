using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IMatchDB<Match>
    {
        void AddMatch(List<Match> matches, Tournament t);
        void GetMatches(Tournament t);
        void SetScore(Match m, Tournament t);
    }
}
