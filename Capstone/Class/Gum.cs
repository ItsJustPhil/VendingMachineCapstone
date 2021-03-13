using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Gum : Product
    {
        public Gum(string name, decimal price) : base(name, price)
        {
        }

        public override string OutPutMessageUponPurchase()
        {
            return "Chew Chew, Yum!";
        }
    }
}
