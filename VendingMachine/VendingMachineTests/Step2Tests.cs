using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step2Tests
    {

        private Itemラック _itemラック;


        [TestInitialize]
        public void TestInitialize()
        {
            _itemラック = Itemラック.ItemラックFactory();
            _itemラック.格納アイテム初期化();
        }

        public static Item.Item MakeCokeDrink()
        {
            return Item.Items.Drink.Factory("コーラ", 100);
        }



        [TestMethod]
        public void コーラを1本在庫として格納できる()
        {
            //コーラ
            var coke = MakeCokeDrink();

            //ラックに格納
            _itemラック.Setアイテム(coke);

            var 格納アイテムリスト = _itemラック.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(coke.Name);
            格納アイテムリスト.First().Price.Is(coke.Price);
            
        }

        [TestMethod]
        public void コーラを5本在庫として格納できる()
        {
            //コーラ
            var coke = MakeCokeDrink();
            
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _itemラック.Setアイテム(coke));

            var 格納アイテムリスト = _itemラック.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.All(n => n.Name == coke.Name).IsTrue();
            格納アイテムリスト.All(n => n.Price == coke.Price).IsTrue();

        }
    }
}
