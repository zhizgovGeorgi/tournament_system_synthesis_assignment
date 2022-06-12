using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITournamentManager
    {
        void AddTournament(Tournament tournament);

        void EditTournament(Tournament t);

        Tournament GetTournament(int id);
        void SignForTournament(Tournament t, User u);
        List<Tournament> GetAllTournaments();
        void UpdateTournamentStatus(Tournament t, Status status);
        void CheckIfComplete(Tournament t);
    }
}
