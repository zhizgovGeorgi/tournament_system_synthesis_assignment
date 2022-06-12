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
            db.GetAllTournamentsAndParticipants(tournaments);
            CheckIfOverDate();
        }

        public void AddTournament(Tournament tournament)
        {
            if (tournaments.Find(x => x.StartDate == tournament.StartDate && x.Adress == tournament.Adress) is null)
            {
                Tournament tournamentWithId = new Tournament(db.GetNextID(), tournament.Name, tournament.Description, tournament.StartDate, tournament.EndDate, tournament.MinCompetitors, tournament.MaxCompetitors, tournament.Adress, tournament.TournamentSystem, tournament.Status);
                db.AddTournament(tournamentWithId);
                tournaments.Add(tournamentWithId);
                return;
            }
            throw new MyException("There is already a tournament with the same start date and location!");


        }

        public void CheckIfOverDate()
        {
            foreach (Tournament t in tournaments)
            {
                if (t.Status == Status.UPCOMING)
                {
                    if (DateTime.Today.AddDays(7).CompareTo(t.StartDate) >= 0)
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
        public void CheckIfComplete(Tournament t)
        {
            if (t is null)
            {
                return;
            }
            if (t.Status == Status.SCHEDULED)
            {
                if (t.Matches.Any(x => x.IsComplete == false))
                {
                    return;
                }
                db.UpdateTournamentStatus(t, Status.COMPLETED);
            }
        }



        public void UpdateTournamentStatus(Tournament t, Status status)
        {
            if (tournaments.Find(x => x.Id == t.Id) != null)
            {
                db.UpdateTournamentStatus(t, status);
                int index = tournaments.FindIndex(x => x.Id == t.Id);
                tournaments[index] = t;
                return;
            }
            throw new MyException("This tournament doesn't exist!");

        }



        public void SignForTournament(Tournament t, User u)

        {
            if (t.Competitors.Find(x => x.Id == u.Id) is null)
            {
                if (DateTime.Now.CompareTo(DateTime.UtcNow.AddDays(7)) < 0)
                {
                    if (t.MaxCompetitors > t.Competitors.Count())
                    {
                        db.SignForTournament(t, u);
                        t.AssignPlayer(u);
                        u.AssignTournament(t);
                        return;
                    }
                }
            }
            throw new MyException("You have already signed in!");
        }

        public Tournament GetTournament(int id)
        {
            return tournaments.Find(x => x.Id == id);
        }

        public List<Tournament> GetAllTournaments()
        {
            return tournaments;
        }

        public void EditTournament(Tournament t)
        {

            if (tournaments.Find(x => x.Id == t.Id) != null)
            {
                db.EditTournament(t);
                int index = tournaments.FindIndex(x => x.Id == t.Id);
                tournaments[index] = t;
                return;
            }
            throw new MyException("This tournament doesn't exist!");
        }

    }
}
