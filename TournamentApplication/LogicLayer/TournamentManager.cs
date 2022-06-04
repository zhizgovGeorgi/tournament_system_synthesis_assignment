using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentManager : ITournamentManager
    {
        List<Tournament> tournaments = new List<Tournament>();
        ITournamentDB<Tournament> db;
        public TournamentManager(ITournamentDB<Tournament> db)
        {
            this.db = db;
            // tournaments =db.GetAllTournaments();
            db.GetAllTournamentsAndParticipants(tournaments);
            CheckIfOverDate();
        }

        public void AddTournament(Tournament tournament)
        {
            try
            {
                db.AddTournament(tournament);
                tournaments.Add(tournament);
            }
            catch (MyException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void CheckIfOverDate()
        {
            foreach (Tournament t in tournaments)
            {
                if (t.Status == Status.UPCOMING)
                {
                    if (DateTime.Today.AddDays(7).CompareTo(t.StartDate) >= 0 )
                    {
                        if (t.Competitors.Count >= t.MinCompetitors)
                        {
                            db.UpdateTournamentStatus(t, Status.OVERDATE);
                            return;
                        }
                        db.UpdateTournamentStatus(t, Status.CANCELED);
                    }
                }
            }
        }



        public void UpdateTournamentStatus(Tournament t, Status status)
        {
            db.UpdateTournamentStatus(t, status);
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

        public bool SignForTournament(Tournament t, User u)
        {
            if (t.Competitors.Find(x => x.Id == u.Id) is null)
            {
                if (t.StartDate > DateTime.Now.AddDays(7))
                {
                    if (t.MaxCompetitors > t.Competitors.Count())
                    {
                        db.SignForTournament(t, u);
                        t.Competitors.Add(u);
                        return true;
                    }
                }
            }
            return false;
        }

        public Tournament GetTournament(int id)
        {
            return tournaments.Find(x => x.Id == id);
        }

        public Tournament GetTournament(string name)
        {
            return tournaments.Find(x => x.Name == name);
        }
        public List<Tournament> GetAllTournaments()
        {
            return tournaments;
        }

    }
}
