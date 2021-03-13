using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyTest
    {
        [TestMethod]
        public void FeedMoneyHappyPathTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(10);
            decimal expectedResult = 10M;

            Assert.AreEqual(expectedResult, vendingMachine.Balance);

            




        }


    }
}
