using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Item
{
    public class Item
    {
        public String Name { get; }
        public int Value { get; }

        private Item(string name,int value)
        {
            Name = name;
            Value = value;
        }


        public static Item ItemFactory(string name, int value)
        {
            return new Item(name,value);
        }


    }
}
