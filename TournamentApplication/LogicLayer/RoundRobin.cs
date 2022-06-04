using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class RoundRobin : TournamentSystem
    {
        public static string Name { get { return "RoundRobin"; } }
        public RoundRobin() : base()
        {


        }

        public override int CalculateRounds(int n)
        {
            if (n % 2 == 0)
            {
                base.Rounds = n - 1;
            }
            else
            {
                base.Rounds = n;
            }
            return Rounds;
        }

        public override int CalculateMatches(int n)
        {
            return base.Matches = (n * (n - 1)) / 2;
        }

        public List<User> CheckIfEvenOrOdd(List<User> competitors)
        {
            if (competitors.Count % 2 != 0)
            {
                User userB = new User("B", "B", "B", "B", "B", "B");
                competitors.Add(userB);
            }
            return competitors;
        }



        public override List<Match> CreateMatchSchedule(List<User> competitors, Tournament t)
        {

            List<Match> schedule = new List<Match>();

            List<User> allCompetitors = CheckIfEvenOrOdd(competitors);


            List<User> topBracket = new List<User>();
            List<User> bottomBracket = new List<User>();

            //separates the whole list with competitors into two equal brackets
            for (int i = 0; i < allCompetitors.Count; i++)
            {
                if (i >= allCompetitors.Count / 2)
                {
                    bottomBracket.Add(allCompetitors[i]);
                }
                else
                {
                    topBracket.Add(allCompetitors[i]);
                }
            }



            for (int i = 0; i < CalculateRounds(allCompetitors.Count()); i++)
            {
                for (int j = 0; j < CalculateMatches(allCompetitors.Count) / CalculateRounds(allCompetitors.Count()); j++)
                {
                    User user1 = topBracket[j];
                    User user2 = bottomBracket[j];
                    Player player1 = new Player(user1, 0);
                    Player player2 = new Player(user2, 0);
                    Match match = new Match(i + 1, j + 1, player1, player2);
                    if (player1.User.Email != "B" && player2.User.Email != "B")
                    {
                        schedule.Add(match);
                    }
                }
                topBracket.Insert(1, bottomBracket.Last());
                bottomBracket.Remove(bottomBracket.Last());
                bottomBracket.Insert(0, topBracket.Last());
                topBracket.Remove(topBracket.Last());
            }
            t.AssignMatches(schedule);
            return schedule;

        }


        public override string ToString()
        {
            return Name;
        }
    }
}
