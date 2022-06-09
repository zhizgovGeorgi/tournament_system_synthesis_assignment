using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerConstructorWithValidData()
        {
            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User");
            Player player = new Player(user, 0);
        }

        [TestMethod]
        public void PlayerConstructorWrongScore()
        {
            User user = new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User");
            Assert.ThrowsException<MyException>(() =>
           new Player(user, -1));
        }




    }
}