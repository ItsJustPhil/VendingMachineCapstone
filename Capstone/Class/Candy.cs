using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Class
{
    public class Candy: Product
    {
        public Candy(string name,decimal price) : base(name,price)
        {
        }

        public override string OutPutMessageUponPurchase()
        {
            return "Munch Munch, Yum!";
        }
    }
}
