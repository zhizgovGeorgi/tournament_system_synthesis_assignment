using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using UnitTests.Mocks;
using System.Collections.Generic;

namespace UnitTests.EntytiTests
{
    [TestClass]
    public class SystemDividerTest
    {
        [TestMethod]
        public void SystemDividerGetRoundRobinAndDouble()
        {
            string systemName = "RoundRobin";
            string systemName2 = "DoubleRoundRobin";

            SystemDivider sd = new SystemDivider();
            TournamentSystem ts = new RoundRobin();
            TournamentSystem ts2 = new DoubleRoundRobin();

            Assert.AreEqual(ts.ToString(), sd.DivideTournamentSystems(systemName).ToString());
          //  Assert.AreEqual(ts2, sd.DivideTournamentSystems(systemName2));
        }


        [TestMethod]
        public void SystemDividerDivideTournamenSystemsWrongData()
        {
            SystemDivider sd = new SystemDivider();
           Assert.ThrowsException<MyException>(() =>
            sd.DivideTournamentSystems("WrongSystemName"));
        }



    }
}