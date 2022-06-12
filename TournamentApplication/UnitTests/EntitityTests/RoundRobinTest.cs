using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using UnitTests.Mocks;
using System.Collections.Generic;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class RoundRobinTest
    {
        [TestMethod]
        public void RoundRobinCalculateRoundsAndMatches()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament tournament = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "12345679", "User");
            User user2 = new User("zaza", "Ivanov", "zaza@abv.bg", "street 1", "12345697", "User");
            User user3 = new User("Lolo", "Ivanov", "lolo@abv.bg", "street 1", "12394567", "User");
            User user4 = new User("Mimi", "Ivanova", "mimi@abv.bg", "street 1", "123994567", "User");
            User user5 = new User("Petra", "Ivanova", "petra@abv.bg", "street 1", "129934567", "User");

            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager tm = new TournamentManager(mt);
            List<User> users = new List<User>();

            tm.AddTournament(tournament);
            users.Add(user);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
            tournament.AssignPlayers(users);


            Assert.AreEqual(5, ts.CalculateRounds(tournament.Competitors.Count));
            Assert.AreEqual(10, ts.CalculateMatches(tournament.Competitors.Count));
        }


        [TestMethod]
        public void RoundRobinCreateSchedule()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament tournament = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            User user = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "skmmkdss", "User");
            User user2 = new User(2, "zaza", "Ivanov", "zaza@abv.bg", "street 1", "skmmkdss", "User");
            User user3 = new User(3, "Lolo", "Ivanov", "lolo@abv.bg", "street 1", "skmmkdss", "User");

            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager tm = new TournamentManager(mt);
            List<User> users = new List<User>();
            List<Match>matches = new List<Match>();

            tm.AddTournament(tournament);
            users.Add(user);
            users.Add(user2);
            users.Add(user3);
            tournament.AssignPlayers(users);

            Match match1 = new Match(1, 1, new Player(user, 0), new Player(user3,0), false);
            Match match2 = new Match(2, 1, new Player(user, 0), new Player(user2,0), false);
            Match match3 = new Match(3, 1, new Player(user3, 0), new Player(user2,0), false);
            matches.Add(match1);
            matches.Add(match2);
            matches.Add(match3);

            Assert.AreEqual(matches.Count, ts.CreateMatchSchedule(tournament).Count);
        }



    }
}