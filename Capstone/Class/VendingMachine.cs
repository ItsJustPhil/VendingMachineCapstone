using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Class
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; }
        public Dictionary<string, Product> ListOfInventory { get; private set; }

        public VendingMachine()
        {
            Balance = 0M;
            ListOfInventory = new Dictionary<string, Product>();
        }


        public bool Stock()
        {
            string inventoryFilePath = Directory.GetCurrentDirectory();
            string inventoryFileName = "vendingmachine.csv";
            string inventoryFullPath = Path.Combine(inventoryFilePath, inventoryFileName);
            try
            {
                using (StreamReader sr = new StreamReader(inventoryFullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] placeholderArray = line.Split('|');
                        switch (placeholderArray[3])
                        {
                            case "Chip":
                                Chip chip = new Chip(placeholderArray[1], decimal.Parse(placeholderArray[2]));
                                ListOfInventory.Add(placeholderArray[0], chip);
                                break;
                            case "Drink":
                                Drink drink = new Drink(placeholderArray[1], decimal.Parse(placeholderArray[2]));
                                ListOfInventory.Add(placeholderArray[0], drink);
                                break;
                            case "Gum":
                                Gum gum = new Gum(placeholderArray[1], decimal.Parse(placeholderArray[2]));
                                ListOfInventory.Add(placeholderArray[0], gum);
                                break;
                            case "Candy":
                                Candy candy = new Candy(placeholderArray[1], decimal.Parse(placeholderArray[2]));
                                ListOfInventory.Add(placeholderArray[0], candy);
                                break;
                            default:
                                return false;
                        }
                    }
                }
            }catch(Exception e)
            {
                return false;
            }return true;
        }

        public string ShowInventory()
        {
            string result = "";
            foreach(KeyValuePair<string, Product> product in ListOfInventory)
            {
                if(product.Value.Amount == 0)
                {
                    result += $"{product.Key}|".PadRight(4) + $"{product.Value.Name}".PadRight(20) + $"|{product.Value.Price:C2} but it is sold out.\n";

                }else
                {
                    result += $"{product.Key}|".PadRight(4) + $"{product.Value.Name}".PadRight(20) + $"|{product.Value.Price:C2}|".PadRight(9) + $"{product.Value.Amount} Remaining.\n";
                }
            }
            return result;
        }

        public string Purchase(string itemIndex)
        {
            if (!ListOfInventory.ContainsKey(itemIndex))
            {
                return "Sorry, that's not a valid slot.";
            }
            else if (ListOfInventory[itemIndex].Price > Balance)
            {
                return "Sorry, please add more money.";
            }
            {
                if (ListOfInventory[itemIndex].BuyOne())
                {
                    decimal beforeBalance = Balance;
                    Balance -= ListOfInventory[itemIndex].Price;
                    try
                    {
                        string logPath = Directory.GetCurrentDirectory();
                        string logFile = "Log.txt";
                        string logFullPath = Path.Combine(logPath, logFile);
                        string currentDateTime = DateTime.Now.ToString();
                        using (StreamWriter sw = new StreamWriter(logFullPath, true))
                        {
                            sw.WriteLine($"{currentDateTime} {ListOfInventory[itemIndex].Name} {itemIndex} {beforeBalance:C2} {Balance:C2}");
                        }
                    }
                    catch
                    {

                    }
                    return $"{ListOfInventory[itemIndex].OutPutMessageUponPurchase()}";
                    
                }
                else
                {
                    return $"Sorry, {ListOfInventory[itemIndex].Name} is out of stock.";
                }
            }
        }

        public string FeedMoney(int deposit)
        {
            string logPath = Directory.GetCurrentDirectory();
            string logFile = "Log.txt";
            string logFullPath = Path.Combine(logPath, logFile);
            string currentDateTime = DateTime.Now.ToString();
            decimal beforeBalance = Balance;
            Balance += deposit;
            try
            {
                using (StreamWriter sw = new StreamWriter(logFullPath, true))
                {
                    sw.WriteLine($"{currentDateTime} FEED MONEY {beforeBalance:C2} {Balance:C2}");
                }
            }
            catch
            {

            }
            return $"Your new balance is {Balance}";
        }

        public Dictionary<string, int> GiveChange()
        {
            string logPath = Directory.GetCurrentDirectory();
            string logFile = "Log.txt";
            string logFullPath = Path.Combine(logPath, logFile);
            string currentDateTime = DateTime.Now.ToString();
            decimal beforeBalance = Balance;
            Dictionary<string, int> change = new Dictionary<string, int>();
            int numberOfQuarters = (int)(Balance / .25M);
            Balance = Balance % .25M;
            int numberOfDimes = (int)(Balance / .10M);
            Balance = Balance % .10M;
            int numberOfNickels = (int)(Balance / .05M);
            Balance = Balance % .05M;
            if (numberOfQuarters > 0) 
            { 
                change.Add("Quarters", numberOfQuarters); 
            }
            if (numberOfDimes > 0)
            {
                change.Add("Dimes", numberOfDimes);
            }
            if (numberOfNickels > 0)
            {
                change.Add("Nickels", numberOfNickels);
            }
            try
            {
                using(StreamWriter sw = new StreamWriter(logFullPath, true))
                {
                    sw.WriteLine($"{currentDateTime} GIVE CHANGE {beforeBalance:C2} {Balance:C2}");
                }
            }
            catch
            {

            }
            return change;            
        }

        public string SalesReport()
        {
            string logFilePath = Directory.GetCurrentDirectory();
            string logFileName = "Log.txt";
            string reportFileName = "SalesReport.txt";
            string logFullPath = Path.Combine(logFilePath, logFileName);
            string reportFullPath = Path.Combine(logFilePath, reportFileName);
            Dictionary<string, int> salesReport = new Dictionary<string, int>();
            foreach (KeyValuePair<string, Product> item in ListOfInventory)
            {
                salesReport.Add(item.Key, 0);
            }
            Dictionary<string, int> salesReportEdit = new Dictionary<string, int>(salesReport);
            try
            {
                decimal totalSales = 0M;
                using (StreamReader sr = new StreamReader(logFullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        foreach(KeyValuePair<string, int> salesItem in salesReport)
                        {
                            if (line.Contains(salesItem.Key))
                            {
                                salesReportEdit[salesItem.Key] += 1;
                                totalSales += ListOfInventory[salesItem.Key].Price;
                            }
                        }
                    }
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(reportFullPath))
                        {
                            foreach (KeyValuePair<string, int> salesItem in salesReportEdit)
                            {
                                sw.WriteLine($"{ListOfInventory[salesItem.Key].Name}|{salesReportEdit[salesItem.Key]}");
                            }
                            sw.WriteLine();
                            sw.WriteLine("*** TOTAL SALES ***");
                            sw.WriteLine($"{totalSales:C2}");
                        }

                    }
                    catch
                    {
                        return "Couldn't write to the sales report file for some reason.";
                    }
                }
                return "Sales report has been generated.";
            }
            catch(Exception error)
            {
                return "Sorry, could not find Log.txt.";
            }

        }
    }

}
