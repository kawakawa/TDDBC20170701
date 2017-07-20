using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.部位
{
    public class アイテムRack
    {

        private static アイテムRack _アイテムRack;

        private readonly List<Item.Item> _格納アイテムリスト;

        private アイテムRack()
        {
            //初期化
            _格納アイテムリスト=new List<Item.Item>();
        }

        public static アイテムRack Factory()
        {
            return _アイテムRack ?? (_アイテムRack=new アイテムRack());
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

        public Item.Item アイテム取出し(string 対象アイテム名)
        {
            var アイテム = _格納アイテムリスト.First(n => n.Name == 対象アイテム名);
            _格納アイテムリスト.Remove(アイテム);

            return アイテム;
        }
    }
}
