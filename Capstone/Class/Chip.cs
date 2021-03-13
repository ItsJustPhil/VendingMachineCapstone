using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Chip : Product
    {
        public Chip(string name, decimal price):base(name,price)
        {
        }

        public override string OutPutMessageUponPurchase()
        {
            return "Crunch Crunch, Yum!";
        }

       
    }
}
