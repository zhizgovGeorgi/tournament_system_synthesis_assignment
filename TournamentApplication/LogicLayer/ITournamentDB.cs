using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITournamentDB<Tournament>
    {
        void DeleteTournament(Tournament t);
        List<Tournament> GetAllTournaments();

        void AddTournament(Tournament t);

        void EditUser(Tournament t);

        void UpdateTournamentStatus(Tournament t, Status status);

        void SignForTournament(Tournament t, User u);

        void GetAllTournamentsAndParticipants(List<Tournament> tournaments);
    }
}
