using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using UnitTests.Mocks;

namespace UnitTests.ManagerTest
{
    [TestClass]
    public class TournamentManagerTests
    {
        [TestMethod]
        public void AddTournamentTest()
        {
            //arrange
            TournamentSystem ts = new RoundRobin();
            Tournament t = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager manager = new TournamentManager(mt);
            //act
            manager.AddTournament(t);
            //assert
            Assert.AreEqual(1, manager.GetAllTournaments().Count);
            Assert.AreEqual("Badminton", t.Name);
            Assert.AreEqual("Descriptive Description of Description", t.Description);
            Assert.AreEqual(2, t.MinCompetitors);
            Assert.AreEqual(10, t.MaxCompetitors);
            Assert.AreEqual("Adress123", t.Adress);
            Assert.AreEqual(Status.UPCOMING, t.Status);
        }

        [TestMethod]
        public void AddSameTournamentTest()
        {
            //arrange
            TournamentSystem ts = new RoundRobin();
            Tournament t = new Tournament(1, "Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Now.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            Tournament t2 = new Tournament(2, "Emperors Badminton Cup", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Now.AddDays(18), 2, 12, "Adress123", ts, Status.UPCOMING);
            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager manager = new TournamentManager(mt);
            //act
            manager.AddTournament(t);
            //assert
            Assert.ThrowsException<MyException>(() =>
           manager.AddTournament(t2));

            Assert.AreEqual(1, manager.GetAllTournaments().Count);

        }

        //[TestMethod]
        //public void SignForTournamentTest()
        //{
        //    TournamentSystem ts = new RoundRobin();
        //    Tournament t = new Tournament(1, "Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Now.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
        //    User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
        //    User u2 = new User(2, "Marin", "Zhizgov", "marin@abv.bg", "street", "1234567", "User");
        //    List<User> users = new List<User>();
        //    List<Tournament> tournaments= new List<Tournament>();

        //    MockTournamentDB mt = new MockTournamentDB();
        //    TournamentManager manager = new TournamentManager(mt);

        //    users.Add(u);
        //    tournaments.Add(t);
        //    u.AssingTournaments(tournaments);
        //    t.AssignPlayers(users);

        //    Assert.AreEqual(true, manager.SignForTournament(t, u2));
        //}

        [TestMethod]
        public void GetTournamentTest()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament t = new Tournament(1, "Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager manager = new TournamentManager(mt);
            manager.AddTournament(t);
            Assert.AreEqual(1, manager.GetTournament(t.Id).Id);
            Assert.AreEqual("Badminton", manager.GetTournament(t.Id).Name);
        }

        [TestMethod]
        public void GetTournamentTest2()
        {
            //arrange
            TournamentSystem ts = new DoubleRoundRobin();
            Tournament t = new Tournament(1, "Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager manager = new TournamentManager(mt);
            //act

            //assert
            Assert.AreEqual(null, manager.GetTournament(t.Id));
        }

        [TestMethod]
        public void GetAllTournamentTest()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament t = new Tournament(1, "Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Now.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            Tournament t2 = new Tournament(2, "Emperors Badminton Cup", "Descriptive Description of Description", DateTime.Today.AddDays(23), DateTime.Now.AddDays(24), 2, 12, "Adress123", ts, Status.UPCOMING);
            MockTournamentDB mt = new MockTournamentDB();
            TournamentManager manager = new TournamentManager(mt);

            List<Tournament> tournaments = new List<Tournament>();
            List<Tournament> tournamentsManagerList = manager.GetAllTournaments();

            manager.AddTournament(t);
            tournaments.Add(t);
            //manager.AddTournament(t2);
            //tournaments.Add(t2);

            Assert.AreEqual(t.Id, tournamentsManagerList.Find(x=>x.Id == t.Id).Id);



        }

    }
}