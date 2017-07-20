using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step4Tests
    {

        private アイテムRack _アイテムRack;


        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = アイテムRack.Factory();
            _アイテムRack.格納アイテム初期化();
        }


        public static Item.Item MakeCokeDrink()
        {
            return Item.Items.Drink.Factory("コーラ", 100);
        }

        public static Item.Item MakeRedBullDrink()
        {
            return Item.Items.Drink.Factory("レッドブル", 200);
        }




        [TestMethod]
        public void レッドブル１本を在庫として格納できる()
        {
            //レッドブル
            var redBull = MakeRedBullDrink();

            //ラックに格納
            _アイテムRack.Setアイテム(redBull);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(redBull.Name);
            格納アイテムリスト.First().Price.Is(redBull.Price);
        }
    }
}
