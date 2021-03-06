﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Item
{
    public class Item
    {
        public string Name { get; }
        public int Price { get; }

        protected Item(string name,int price)
        {
            Name = name;
            Price = price;
        }


        public static Item ItemFactory(string name, int price)
        {
            return new Item(name,price);
        }

        
    }
}
