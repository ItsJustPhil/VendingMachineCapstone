using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Drink:Product
    {
        public Drink(string name, decimal price) : base(name,price)
        {
        }

        public override string OutPutMessageUponPurchase()
        {
            return "Glug Glug, Yum!";
        }
    }
}
