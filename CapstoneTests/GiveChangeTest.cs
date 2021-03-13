using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class GiveChangeTest
    {
        [TestMethod]
        public void GiveChangeHappyPathatest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(5);
            vendingMachine.Purchase("A1");
            Dictionary<string, int> expectedResult = new Dictionary<string, int>();
            expectedResult.Add("Quarters", 7);
            expectedResult.Add("Dimes", 2);

            Dictionary<string, int> actualResult = vendingMachine.GiveChange();

            CollectionAssert.AreEqual(expectedResult, actualResult);

        }
    }
}
