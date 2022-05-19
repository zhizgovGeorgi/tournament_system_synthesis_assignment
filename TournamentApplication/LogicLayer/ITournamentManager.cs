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

        void RemoveTournament(Tournament t);

        Tournament GetTournament(Tournament t);

        List<Tournament> GetAllTournaments();
    }
}
