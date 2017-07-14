using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step2Tests
    {
        [TestMethod]
        public void コーラを1本在庫として格納できる()
        {
            //コーラ
            var coke = Item.Items.Drink.Factory("コーラ", 100);

            //ラックに格納
            var itemラック = Itemラック.ItemラックFactory();
            itemラック.格納アイテム初期化();

            itemラック.SetItem(coke);

            var 格納アイテムリスト = itemラック.GetItemList();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(coke.Name);
            格納アイテムリスト.First().Price.Is(coke.Price);
            
        }

        [TestMethod]
        public void コーラを5本在庫として格納できる()
        {
            //コーラ
            var coke = Item.Items.Drink.Factory("コーラ", 100);

            //ラックに5本格納
            var itemラック = Itemラック.ItemラックFactory();
            itemラック.格納アイテム初期化();

            Enumerable.Range(1, 5).ToList()
                .ForEach(i => itemラック.SetItem(coke));

            var 格納アイテムリスト = itemラック.GetItemList();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.All(n => n.Name == coke.Name).IsTrue();
            格納アイテムリスト.All(n => n.Price == coke.Price).IsTrue();

        }
    }
}
