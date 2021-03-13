using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public abstract class Product
    {
        
        public string Name { get; }
        public decimal Price { get; }
        public int Amount { get; private set; }
        public string ProductType { get; set; }
        public Product (string name, decimal price)
        {
            Name = name;
            Price = price;
            Amount = 5;
        }
        public bool BuyOne()
        {
            if(Amount > 0)
            {
                Amount--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract string OutPutMessageUponPurchase();
    }
}
