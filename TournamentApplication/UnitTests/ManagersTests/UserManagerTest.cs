using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using UnitTests.Mocks;

namespace UnitTests.ManagerTest
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void AddUserTest()
        {
            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act
            manager.AddUser(u);
            //assert
            Assert.AreEqual(1, manager.GetAllUsers().Count);
            Assert.AreEqual("Georgi", u.FName);
            Assert.AreEqual("Zhizgov", u.LName);
            Assert.AreEqual("g.antoanov@abv.bg", u.Email);
            Assert.AreEqual("street", u.Adress);
            Assert.AreEqual("1234567", u.Password);
            Assert.AreEqual("User", u.Role);
        }

        [TestMethod]
        public void AddSameUserTest()
        {
            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            User u2 = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act
            manager.AddUser(u);
            //manager.AddUser(u2);
            //assert
            Assert.AreEqual(1, manager.GetAllUsers().Count);
            Assert.ThrowsException<MyException>(() =>
            manager.AddUser(u2));

        }

        [TestMethod]
        public void GetUserTest()
        {
            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act
            manager.AddUser(u);
            //assert
            Assert.AreEqual(u, manager.GetUser(u.Email, u.Password));

        }

        [TestMethod]
        public void GetUserTest2()
        {
            //user won't be created so the method will return null

            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act

            //assert
            Assert.ThrowsException<MyException>(() =>
            manager.GetUser(u.Email, u.Password));

        }

        [TestMethod]
        public void GetUserByEmailTest()
        {
            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act
            manager.AddUser(u);
            //assert
            Assert.AreEqual(u, manager.GetUserByEmail(u.Email));

        }

        [TestMethod]
        public void GetUserByEmailTest2()
        {
            //arrange
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            //act

            //assert
            Assert.AreEqual(null, manager.GetUserByEmail(u.Email));

        }

        [TestMethod]
        public void GetAllUsers()
        {
            User u = new User(1, "Georgi", "Zhizgov", "g.antoanov@abv.bg", "street", "1234567", "User");
            User u2 = new User(1, "Gergana", "Miteva", "geri@abv.bg", "street13", "1234567", "User");

            MockUserDB mu = new MockUserDB();
            UserManager manager = new UserManager(mu);
            List<User> users = new List<User>();
            List<User> usersManagerList = manager.GetAllUsers();

            manager.AddUser(u);
            users.Add(u);
            manager.AddUser(u2);
            users.Add(u2);

            CollectionAssert.AreEqual(usersManagerList, users); 


        }


    }
}