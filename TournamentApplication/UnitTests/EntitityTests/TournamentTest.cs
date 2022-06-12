using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class TournamentTest
    {
        [TestMethod]
        public void TournamentConstructorWithValidData()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament tournament = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            Assert.IsNotNull(tournament);
            Assert.AreEqual("Badminton", tournament.Name);
            Assert.AreEqual("Descriptive Description of Description", tournament.Description);
            Assert.AreEqual(DateTime.Today.AddDays(16), tournament.StartDate);
            Assert.AreEqual(DateTime.Today.AddDays(18), tournament.EndDate);
            Assert.AreEqual(2, tournament.MinCompetitors);
            Assert.AreEqual(10, tournament.MaxCompetitors);
            Assert.AreEqual("Adress123", tournament.Adress);
            Assert.AreEqual(ts, tournament.TournamentSystem);
            Assert.AreEqual(Status.UPCOMING, tournament.Status);
        }

        [TestMethod]
        public void TournamentConstructorWrongStartDate()
        {
            Assert.ThrowsException<MyException>(() =>
           new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(6), DateTime.Today.AddDays(18), 2, 10, "Adress", new RoundRobin(), Status.UPCOMING));
        }

        [TestMethod]
        public void TournamentConstructorWrongEndDate()
        {
            Assert.ThrowsException<MyException>(() =>
           new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(15), 2, 10, "Adress", new RoundRobin(), Status.UPCOMING));
        }

        [TestMethod]
        public void TournamentConstructorWrongMinCompetitors()
        {
            Assert.ThrowsException<MyException>(() =>
       new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 0, 10, "Adress123", new RoundRobin(), Status.UPCOMING));
        }

        [TestMethod]
        public void TournamentConstructorWrongMaxCompetitors()
        {
            Assert.ThrowsException<MyException>(() =>
       new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 6, 4, "Adress123", new RoundRobin(), Status.UPCOMING));
        }

        [TestMethod]
        public void TournamentAssignMethod()
        {
            TournamentSystem ts = new RoundRobin();
            Tournament tournament = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Today.AddDays(16), DateTime.Today.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            //Tournament tournament2 = new Tournament("Nationals", "Descriptive Description of Description", DateTime.Now.AddDays(25), DateTime.Now.AddDays(28), 2, 10, "Adress", ts, Status.UPCOMING);
            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User");
            User user2 = new User("Antoan", "Antoanov", "antoanov@abv.bg", "street 1", "1234567", "User");
            List<User> users = new List<User>();
            users.Add(user);
            tournament.AssignPlayers(users);
            tournament.AssignPlayer(user2);
            // Assert.IsNotNull(user);
            Assert.AreEqual(2, tournament.Competitors.Count);
        }

    }
}