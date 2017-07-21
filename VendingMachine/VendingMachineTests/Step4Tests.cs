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


        [TestMethod]
        public void レッドブル１本を在庫として格納できる()
        {
            //レッドブル
            var redBull = Util.MakeRedBullDrink();

            //ラックに格納
            _アイテムRack.Setアイテム(redBull);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(redBull.Name);
            格納アイテムリスト.First().Price.Is(redBull.Price);
        }


        [TestMethod]
        public void レッドブル5本を在庫として格納できる()
        {
            //レッドブル
            var redBull = Util.MakeRedBullDrink();

            //ラックに格納
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _アイテムRack.Setアイテム(redBull));

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.First().Name.Is(redBull.Name);
            格納アイテムリスト.First().Price.Is(redBull.Price);
        }

        [TestMethod]
        public void 水１本を在庫として格納できる()
        {
            //水
            var water = Util.MakeWaterDrink();

            //ラックに格納
            _アイテムRack.Setアイテム(water);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(water.Name);
            格納アイテムリスト.First().Price.Is(water.Price);
        }


        [TestMethod]
        public void 水5本を在庫として格納できる()
        {
            //水
            var water = Util.MakeWaterDrink();

            //ラックに格納
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _アイテムRack.Setアイテム(water));

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.First().Name.Is(water.Name);
            格納アイテムリスト.First().Price.Is(water.Price);
        }







    }
}
