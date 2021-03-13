using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class UI
    {
        public VendingMachine VendingMachine { get; private set; }
        public UI()
        {
            VendingMachine = new VendingMachine();
            VendingMachine.Stock();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to your Vendo-Matic 800!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        }

        public void MainMenu()
        {
            bool keepAsking = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit\n");
                Console.Write("Please select an option: ");
                string userInput = Console.ReadLine().Trim();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine(VendingMachine.ShowInventory());
                        break;
                    case "2":
                        bool validItem = true;
                        do
                        {
                            PurchasingMenu();
                        } while (!validItem);
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        keepAsking = false;
                        break;
                    case "4":
                        VendingMachine.SalesReport();
                        Console.WriteLine("Secret!");
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please choose an option above");
                        break;                      
                }
            } while (keepAsking);

        }

        public void PurchasingMenu()
        {
            bool purchasing = true;
            bool addingMoney = true;
            do
            {
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("        Vendo-Matic 800");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: {VendingMachine.Balance:C2}");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string userPurchaseInput = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                switch (userPurchaseInput)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please add money to your account: ($X Format please)");
                            string moneyToAdd = Console.ReadLine();
                            try
                            {
                                if (moneyToAdd.StartsWith('$'))
                                {
                                    if(int.Parse(moneyToAdd.Substring(1)) > 0)
                                    {
                                        VendingMachine.FeedMoney(int.Parse(moneyToAdd.Substring(1)));
                                        addingMoney = false;
                                    }
                                    else
                                    {
                                        Console.Write("The number must be positive");
                                        Console.ReadLine();
                                    }

                                }

                            }
                            catch
                            {
                                Console.Write("Please try again ($X Format please)\n");
                                Console.ReadLine();
                            }
                        } while (addingMoney);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case "2":
                            Console.WriteLine(VendingMachine.ShowInventory());
                            Console.WriteLine();
                            Console.Write("Please select the item you'd like to purchase: ");
                            string userSelection = Console.ReadLine().ToUpper();
                        if (VendingMachine.ListOfInventory.ContainsKey(userSelection) && VendingMachine.ListOfInventory[userSelection].Amount > 0 && !(VendingMachine.ListOfInventory[userSelection].Price > VendingMachine.Balance))
                        {
                            Console.WriteLine($"You bought {VendingMachine.ListOfInventory[userSelection].Name} for {VendingMachine.ListOfInventory[userSelection].Price:C2}, you have {VendingMachine.Balance - VendingMachine.ListOfInventory[userSelection].Price:C2} remaining.");
                        }
                        string itemBought = VendingMachine.Purchase(userSelection);
                        Console.WriteLine(itemBought);
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the purchase menu");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Your Change is {VendingMachine.Balance:C2}");
                        Dictionary<string, int> changeGiven = VendingMachine.GiveChange();
                        Console.WriteLine("Paying out as: ");
                        foreach(KeyValuePair<string, int> coin in changeGiven)
                        {
                            Console.WriteLine($"{coin.Value} {coin.Key}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\");
                        Console.WriteLine("Thanks for Shopping the Vendo-Matic 800!");
                        Console.WriteLine("          Please come again!");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine();
                        purchasing = false;
                        break;
                    default:
                        Console.WriteLine("Please select an option above");
                        Console.ReadLine();
                        break;
                }
            } while (purchasing);
          

        }
    }
}
