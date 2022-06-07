using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Tournament
    {
        private int id;
        private string name;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int minCompetitors;
        private int maxCompetitors;
        private string adress;
        private TournamentSystem tournamentSystem;
        private List<User> competitors;
        private List<Match> matches;
        private Status status;


        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public string Description { get { return this.description; } }
        public DateTime StartDate
        {
            get { return this.startDate; }
            private set
            {
                if (value.CompareTo(DateTime.UtcNow.AddDays(14)) < 0)
                {
                    throw new MyException("Tournament should have at least two weeks in advance!");
                }
                this.startDate = value;
            }
        }
        public DateTime EndDate
        {
            get { return this.endDate; }
            private set
            {
                if (value.CompareTo(startDate) < 0)
                {
                    throw new MyException("End date cannot be after the start date!");
                }
                this.endDate = value;
            }
        }
        public int MinCompetitors
        {
            get { return this.minCompetitors; }
            private set
            {
                if (value < 2)
                {
                    throw new MyException("Minimum count should not be less than 2");
                }
                this.minCompetitors = value;
            }
        }
        public int MaxCompetitors
        {
            get { return this.maxCompetitors; }
            private set
            {
                if (value < 2)
                {
                    throw new MyException("Maximum count should not be less than 2");
                }
                else if (value < minCompetitors)
                {
                    throw new MyException("Minimum count should not be more than the maximum count");
                }
                this.maxCompetitors = value;
            }
        }
        public string Adress { get { return this.adress; } }
        public TournamentSystem TournamentSystem { get { return this.tournamentSystem; } }
        public List<User> Competitors { get { return this.competitors; } }
        public List<Match> Matches { get { return this.matches; } }

        public Status Status { get { return this.status; } }


        public Tournament(int id, string name, string description, DateTime startDate, DateTime endDate, int minCompetitors, int maxCompetitors, string adress, TournamentSystem tournamentSystem, Status status)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minCompetitors = minCompetitors;
            this.maxCompetitors = maxCompetitors;
            this.adress = adress;
            this.tournamentSystem = tournamentSystem;
            this.status = status;
        }

        public Tournament(string name, string description, DateTime startDate, DateTime endDate, int minCompetitors, int maxCompetitors, string adress, TournamentSystem tournamentSystem, Status status)
        {
            this.name = name;
            this.description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MinCompetitors = minCompetitors;
            this.MaxCompetitors = maxCompetitors;
            this.adress = adress;
            this.tournamentSystem = tournamentSystem;
            this.status = status;
        }



        public void AssignCompetitor(User u)
        {
            competitors.Add(u);
        }

       
        public void AssignPlayers(List<User> users)
        {
            this.competitors = users;
        }

        public void AssignMatches(List<Match> matches)
        {
            this.matches = matches;

        }
        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} start date: {StartDate.ToShortDateString()} to {EndDate.ToShortDateString()}";
        }

    }
}
