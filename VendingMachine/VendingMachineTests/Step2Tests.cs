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
            var coke = Item.Factory.ジュース.Factory("コーラ", 100);

            var itemラック = Itemラック.ItemラックFactory();

            itemラック.SetItem(coke);

            var 在庫リスト = itemラック.GetItemList();
            在庫リスト.Count().Is(1);
            在庫リスト.First().Name.Is(coke.Name);
            在庫リスト.First().Value.Is(coke.Value);


        }
    }
}
