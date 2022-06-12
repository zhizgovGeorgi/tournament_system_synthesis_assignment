using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class MockTournamentDB : ITournamentDB<Tournament>
    {
        public void AddTournament(Tournament t)
        {
            
        }

        public void EditTournament(Tournament t)
        {
            
        }

        public void GetAllTournamentsAndParticipants(List<Tournament> tournaments)
        {
            tournaments = new List<Tournament>();
        }

        public int GetNextID()
        {
            return 1;
        }

        public void SignForTournament(Tournament t, User u)
        {
    
        }

        public void UpdateTournamentStatus(Tournament t, Status status)
        {
            
        }
    }
}
