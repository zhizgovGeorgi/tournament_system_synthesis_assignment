using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void MatchConstructorWithValidData()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);
            // Assert.IsNotNull(user);
            Assert.AreEqual(player1, match.Player1);
            Assert.AreEqual(player1.User, match.Player1.User);
            Assert.AreEqual(player1.Score, match.Player1.Score);
            Assert.AreEqual(player2, match.Player2);
            Assert.AreEqual(player2.User, match.Player2.User);
            Assert.AreEqual(player2.Score, match.Player2.Score);
            Assert.AreEqual(5, match.Rounds);
            Assert.AreEqual(10, match.Matches);
            Assert.AreEqual(false, match.IsComplete);
        }

        [TestMethod]
        public void MatchConstructorSamePlayers()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            //Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Assert.ThrowsException<MyException>(() =>
            new Match(5, 10, player1, player2, false));
        }

        [TestMethod]
        public void MatchSetCorrectScore()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);
            match.SetScore(21,18);
            Assert.AreEqual(21, match.Player1.Score);
            Assert.AreEqual(18, match.Player2.Score);

            
        }

        [TestMethod]
        public void MatchSetWrongScore()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);

            //setting the score over 20 and under 30 with less than 2 points
            //difference
            Assert.ThrowsException<MyException>(() =>
            match.SetScore(23,22));
        }

        [TestMethod]
        public void MatchSetWrongScore2()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);

            //setting the score over 20 and under 30 with less than 2 points
            //difference
            Assert.ThrowsException<MyException>(() =>
            match.SetScore(23, 22));
        }

        [TestMethod]
        public void MatchSetWrongScore3()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);

            //setting the score for less than 21 points
            Assert.ThrowsException<MyException>(() =>
            match.SetScore(18, 19));
        }

        [TestMethod]
        public void MatchSetWrongScore4()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);

            //setting the score for more than 30 points
            Assert.ThrowsException<MyException>(() =>
            match.SetScore(31, 32));
        }

        [TestMethod]
        public void MatchSetWrongScore5()
        {
            Player player1 = new Player(new User("Georgi", "Zhizgov", "g.antoanov@abv.bg", "street 1", "1234567", "User"), 0);
            Player player2 = new Player(new User("Martin", "Todorov", "marti@abv.bg", "street 1", "1234567", "User"), 0);
            Match match = new Match(5, 10, player1, player2, false);

            //setting equal score
            Assert.ThrowsException<MyException>(() =>
            match.SetScore(21, 21));
        }




    }
}