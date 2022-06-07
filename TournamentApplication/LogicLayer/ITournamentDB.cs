using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITournamentDB<Tournament>
    {
        int GetNextID();

        void AddTournament(Tournament t);

        void EditTournament(Tournament t);

        void UpdateTournamentStatus(Tournament t, Status status);

        void SignForTournament(Tournament t, User u);

        void GetAllTournamentsAndParticipants(List<Tournament> tournaments);

        
    }
}
