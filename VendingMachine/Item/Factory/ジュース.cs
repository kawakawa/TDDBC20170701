using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item.Factory
{
    public static class ジュース
    {
        public static Item Factory(string name, int value)
        {
            return Item.ItemFactory(name, value);
        }
    }
}
