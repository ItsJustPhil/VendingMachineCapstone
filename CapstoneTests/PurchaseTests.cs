using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseTests
    {

        [TestMethod]
        public void PurchaseBuyItemHappyPath()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(20);
            string expectedResult = "Glug Glug, Yum!";

            //Act
            string actualResult = vendingMachine.Purchase("C1");

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(18.75M, vendingMachine.Balance);

            //Arrange
            VendingMachine vendingMachine2 = new VendingMachine();
            vendingMachine2.Stock();
            vendingMachine2.FeedMoney(20);
            string expectedResult2 = "Crunch Crunch, Yum!";

            //Act
            string actualResult2 = vendingMachine2.Purchase("A2");

            //Assert
            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(18.55M, vendingMachine2.Balance);

        }

        [TestMethod]
        public void PuchaseBuySoldOutItem()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(20);
            vendingMachine.Purchase("A1");
            vendingMachine.Purchase("A1");
            vendingMachine.Purchase("A1");
            vendingMachine.Purchase("A1");
            vendingMachine.Purchase("A1");
            string expectedResult = "Sorry, Potato Crisps is out of stock.";

            string actualResult = vendingMachine.Purchase("A1");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PurchaseNonValidItem()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(20);
            string expectedResult = "Sorry, that's not a valid slot.";

            string actualResult = vendingMachine.Purchase("G3");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PurchaseNotEnoughMoney()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            string expectedResult = "Sorry, please add more money.";

            string actualResult = vendingMachine.Purchase("A1");

            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
