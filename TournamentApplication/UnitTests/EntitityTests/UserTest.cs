using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserConstructorWithValidData()
        {

            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User");
            // Assert.IsNotNull(user);
            Assert.AreEqual("Georgi", user.FName);
            Assert.AreEqual("Zhizgov", user.LName);
            Assert.AreEqual("g.antoanov@abv.bg", user.Email);
            Assert.AreEqual("street 1", user.Adress);
            Assert.AreEqual("1234567", user.Password);
            Assert.AreEqual("User", user.Role);
        }

        [TestMethod]
        public void UserConstructorWrongPassword()
        {
            Assert.ThrowsException<MyException>(() =>
            new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234", "User"));
        }

        [TestMethod]
        public void UserConstructorEmptyName()
        {
            Assert.ThrowsException<MyException>(() =>
            new User("", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234111", "User"));
        }

        [TestMethod]
        public void UserConstructorEmptyLastName()
        {
            Assert.ThrowsException<MyException>(() =>
            new User("Georgi", "", "g.antoanov@abv.bg", "street 1", "1234111", "User"));
        }

        [TestMethod]
        public void UserConstructorEmptyAdress()
        {
            Assert.ThrowsException<MyException>(() =>
            new User("Georgi", "zhizgov", "g.antoanov@abv.bg", "", "1234111", "User"));
        }

        [TestMethod]
        public void UserAssignMethod()
        {
            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User");
            TournamentSystem ts = new RoundRobin();
            Tournament tournament = new Tournament("Badminton", "Descriptive Description of Description", DateTime.Now.AddDays(16), DateTime.Now.AddDays(18), 2, 10, "Adress123", ts, Status.UPCOMING);
            Tournament tournament2 = new Tournament("Badminton Cup", "Descriptive Description of Description", DateTime.Now.AddDays(20), DateTime.Now.AddDays(25), 2, 10, "Adress123", ts, Status.UPCOMING);
            List<Tournament> tournaments = new List<Tournament>();
            
            tournaments.Add(tournament);
            user.AssingTournaments(tournaments);
            user.AssignTournament(tournament2);

            Assert.AreEqual(2, user.Tournaments.Count);
            Assert.AreEqual("Badminton", user.Tournaments.Find(x=>x.Name == tournament.Name).Name);
            Assert.AreEqual("Badminton Cup", user.Tournaments.Find(x=>x.Name == tournament2.Name).Name);
        }



    }
}