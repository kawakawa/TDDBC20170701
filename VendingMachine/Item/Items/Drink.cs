using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item.Items
{
    public class Drink :Item
    {
        private Drink(string name, int price) : base(name, price)
        {
        }

        public static Item Factory(string name, int price)
        {
            return new Drink(name,price);
        }
    }
}
