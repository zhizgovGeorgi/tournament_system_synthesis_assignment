using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentManager : ITournamentManager
    {
        List<Tournament> tournaments;
        ITournamentDB<Tournament> db;
        public TournamentManager(ITournamentDB<Tournament> db)
        {
            this.db = db;
            tournaments = db.GetAllTournaments();
        }

        public void AddTournament(Tournament tournament)
        {
            if (tournaments.Find(x => x.Name == tournament.Name) is null)
            {
                db.AddTournament(tournament);
                tournaments.Add(tournament);
            }
        }


        public void RemoveTournament(Tournament t)
        {
            if (tournaments.Find(x => x.Id == t.Id) != null)
            {
                db.DeleteTournament(t);
                tournaments.Remove(t);
            }
        }
        public Tournament GetTournament(Tournament t)
        {
            return tournaments.Find(x => x.Name == t.Name);
        }

        public List<Tournament> GetAllTournaments()
        {
            return tournaments;
        }

    }
}
