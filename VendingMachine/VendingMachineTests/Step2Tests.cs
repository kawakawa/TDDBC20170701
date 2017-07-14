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

            var itemラック = Itemラック.ItemラックFactory();

            itemラック.SetItem(coke);

            var 格納アイテムリスト = itemラック.GetItemList();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(coke.Name);
            格納アイテムリスト.First().Price.Is(coke.Price);
            
        }
    }
}
