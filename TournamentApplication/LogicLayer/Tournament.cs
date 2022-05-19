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
        private string tournamentSystem;


        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public string Description { get { return this.description; } }
        public DateTime StartDate { get { return this.startDate; } }
        public DateTime EndDate { get { return this.endDate; } }
        public int MinCompetitors { get { return this.minCompetitors; } }
        public int MaxCompetitors { get { return this.maxCompetitors; } }
        public string Adress { get { return this.adress; } }
        public string TournamentSystem { get { return this.tournamentSystem; } }


        public Tournament(int id, string name, string description,DateTime startDate, DateTime endDate, int minCompetitors, int maxCompetitors, string adress, string tournamentSystem)
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
        }

        public Tournament(string name, string description, DateTime startDate, DateTime endDate, int minCompetitors, int maxCompetitors, string adress, string tournamentSystem)
        {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minCompetitors = minCompetitors;
            this.maxCompetitors = maxCompetitors;
            this.adress = adress;
            this.tournamentSystem = tournamentSystem;
        }

        public Tournament()
        {

        }

        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} start date: {StartDate} to {EndDate}";
        }
    }
}
