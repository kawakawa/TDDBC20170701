using System.Collections.Generic;

namespace VendingMachine
{
    public class Itemラック
    {

        private static Itemラック _itemラック;

        private readonly List<Item.Item> _格納アイテムリスト;

        private Itemラック()
        {
            //初期化
            _格納アイテムリスト=new List<Item.Item>();
        }

        public static Itemラック ItemラックFactory()
        {
            return _itemラック ?? (_itemラック=new Itemラック());
        }


        public void Setアイテム(Item.Item item)
        {
            _格納アイテムリスト.Add(item);
        }

        public IEnumerable<Item.Item> Get格納アイテムリスト()
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
