using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class MockMatchDB : IMatchDB<Match>
    {
        private bool AddMatchCalled;

        public void AddMatch(List<Match> matches, Tournament t)
        {
            this.AddMatchCalled = true;
        }

        public void GetMatches(Tournament t)
        {
        }

        public void SetScore(Match m, Tournament t)
        {
        }
    }
}
