using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Class;

namespace CapstoneTests
{
    [TestClass]
    public class ShowInventoryTests
    {
        [TestMethod]
        public void ShowInventoryStartUpHappyPath() 
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            string expectedResult = "A1: Potato Crisps is $3.05, 5 Remaining.\n" +
                "A2: Stackers is $1.45, 5 Remaining.\n" +
                "A3: Grain Waves is $2.75, 5 Remaining.\n" +
                "A4: Cloud Popcorn is $3.65, 5 Remaining.\n" +
                "B1: Moonpie is $1.80, 5 Remaining.\n" +
                "B2: Cowtales is $1.50, 5 Remaining.\n" +
                "B3: Wonka Bar is $1.50, 5 Remaining.\n" +
                "B4: Crunchie is $1.75, 5 Remaining.\n" +
                "C1: Cola is $1.25, 5 Remaining.\n" +
                "C2: Dr. Salt is $1.50, 5 Remaining.\n" +
                "C3: Mountain Melter is $1.50, 5 Remaining.\n" +
                "C4: Heavy is $1.50, 5 Remaining.\n" +
                "D1: U-Chews is $0.85, 5 Remaining.\n" +
                "D2: Little League Chew is $0.95, 5 Remaining.\n" +
                "D3: Chiclets is $0.75, 5 Remaining.\n" +
                "D4: Triplemint is $0.75, 5 Remaining.\n";

            //Act
            string actualResult = vendingMachine.ShowInventory();

            //Arrange
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShowInventorySomeSoldHappyPath()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(20);
            vendingMachine.Purchase("D2");
            vendingMachine.Purchase("D2");
            vendingMachine.Purchase("D2");
            vendingMachine.Purchase("B3");
            vendingMachine.Purchase("B3");
            vendingMachine.Purchase("A4");
            string expectedResult = "A1: Potato Crisps is $3.05, 5 Remaining.\n" +
                "A2: Stackers is $1.45, 5 Remaining.\n" +
                "A3: Grain Waves is $2.75, 5 Remaining.\n" +
                "A4: Cloud Popcorn is $3.65, 4 Remaining.\n" +
                "B1: Moonpie is $1.80, 5 Remaining.\n" +
                "B2: Cowtales is $1.50, 5 Remaining.\n" +
                "B3: Wonka Bar is $1.50, 3 Remaining.\n" +
                "B4: Crunchie is $1.75, 5 Remaining.\n" +
                "C1: Cola is $1.25, 5 Remaining.\n" +
                "C2: Dr. Salt is $1.50, 5 Remaining.\n" +
                "C3: Mountain Melter is $1.50, 5 Remaining.\n" +
                "C4: Heavy is $1.50, 5 Remaining.\n" +
                "D1: U-Chews is $0.85, 5 Remaining.\n" +
                "D2: Little League Chew is $0.95, 2 Remaining.\n" +
                "D3: Chiclets is $0.75, 5 Remaining.\n" +
                "D4: Triplemint is $0.75, 5 Remaining.\n";

            //Act
            string actualResult = vendingMachine.ShowInventory();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void ShowInventorySoldOutItemHappyPath()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Stock();
            vendingMachine.FeedMoney(20);
            vendingMachine.Purchase("A2");
            vendingMachine.Purchase("A2");
            vendingMachine.Purchase("A2");
            vendingMachine.Purchase("A2");
            vendingMachine.Purchase("A2");
            string expectedResult = "A1: Potato Crisps is $3.05, 5 Remaining.\n" +
                "A2: Stackers is $1.45 but it is sold out.\n" +
                "A3: Grain Waves is $2.75, 5 Remaining.\n" +
                "A4: Cloud Popcorn is $3.65, 5 Remaining.\n" +
                "B1: Moonpie is $1.80, 5 Remaining.\n" +
                "B2: Cowtales is $1.50, 5 Remaining.\n" +
                "B3: Wonka Bar is $1.50, 5 Remaining.\n" +
                "B4: Crunchie is $1.75, 5 Remaining.\n" +
                "C1: Cola is $1.25, 5 Remaining.\n" +
                "C2: Dr. Salt is $1.50, 5 Remaining.\n" +
                "C3: Mountain Melter is $1.50, 5 Remaining.\n" +
                "C4: Heavy is $1.50, 5 Remaining.\n" +
                "D1: U-Chews is $0.85, 5 Remaining.\n" +
                "D2: Little League Chew is $0.95, 5 Remaining.\n" +
                "D3: Chiclets is $0.75, 5 Remaining.\n" +
                "D4: Triplemint is $0.75, 5 Remaining.\n";

            //Act
            string actualResult = vendingMachine.ShowInventory();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
