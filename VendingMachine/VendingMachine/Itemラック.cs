using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Itemラック
    {
        private static Itemラック _itemラック;

        private Itemラック()
        {
        }

        public static Itemラック ItemラックFactory()
        {
            return _itemラック ?? (_itemラック=new Itemラック());
        }


        public void SetItem(Item.Item item)
        {
        }

        public IEnumerable<Item.Item> GetItemList()
        {
            var list=new List<Item.Item>();
            list.Add(new Item.Item());
            return list;
        }
    }
}
