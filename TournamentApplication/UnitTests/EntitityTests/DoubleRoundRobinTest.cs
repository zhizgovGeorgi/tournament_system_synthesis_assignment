using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using UnitTests.Mocks;
using System.Collections.Generic;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class DoubleRoundRobinTest
    {
        [TestMethod]
        public void DoubleRoundRobinCalculateRounds()
        {
            TournamentSystem ts = new DoubleRoundRobin();
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


            Assert.AreEqual(10, ts.CalculateRounds(tournament.Competitors.Count));
            Assert.AreEqual(20, ts.CalculateMatches(tournament.Competitors.Count));
        }



    }
}