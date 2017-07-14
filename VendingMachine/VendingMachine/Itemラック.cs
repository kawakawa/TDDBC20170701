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

        private List<Item.Item> _格納アイテムリスト;

        private Itemラック()
        {
            _格納アイテムリスト=new List<Item.Item>();
        }

        public static Itemラック ItemラックFactory()
        {
            return _itemラック ?? (_itemラック=new Itemラック());
        }


        public void SetItem(Item.Item item)
        {
            _格納アイテムリスト.Add(item);
        }

        public IEnumerable<Item.Item> GetItemList()
        {
            var list=new List<Item.Item>();
            list.AddRange(_格納アイテムリスト);
            return list;
        }

        public void 格納アイテム初期化()
        {
            _格納アイテムリスト.Clear();
        }

    }
}
