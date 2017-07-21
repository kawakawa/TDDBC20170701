using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step4Tests
    {

        private アイテムRack _アイテムRack;
        private 投入金 _投入金;
        private 投入口 _投入口;

        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = アイテムRack.Factory();
            _アイテムRack.格納アイテム初期化();


            _投入金 = 投入金.Factory();
            _投入金.投入金額歴初期化();

            _投入口 = 投入口.Factory(_投入金);
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


        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で100円投下した時購入可能なのはコーラと水だけであるか()
        {

            var coke = Util.MakeCokeDrink();
            var redbull = Util.MakeRedBullDrink();
            var water = Util.MakeWaterDrink();

            _アイテムRack.Setアイテム(coke);
            _アイテムRack.Setアイテム(redbull);
            _アイテムRack.Setアイテム(water);

            _投入口.投入(MoneyKind.Yen100);



            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(2);
            購入可能アイテムリスト.Any(n => n.Name == coke.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == water.Name).IsTrue();
        }

        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で200円投下した時購入可能なのはコーラとレッドブルと水であるか()
        {

            var coke = Util.MakeCokeDrink();
            var redbull = Util.MakeRedBullDrink();
            var water = Util.MakeWaterDrink();

            _アイテムRack.Setアイテム(coke);
            _アイテムRack.Setアイテム(redbull);
            _アイテムRack.Setアイテム(water);


            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);
            

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(3);
            購入可能アイテムリスト.Any(n => n.Name == coke.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == redbull.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == water.Name).IsTrue();
        }



        [TestMethod]
        public void コーラ_レッドブルだけを格納した状態で100円投下した時購入可能なのはコーラだけであるか()
        {

            var coke = Util.MakeCokeDrink();
            var redbull = Util.MakeRedBullDrink();

            _アイテムRack.Setアイテム(coke);
            _アイテムRack.Setアイテム(redbull);

            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == coke.Name).IsTrue();
        }


        [TestMethod]
        public void レッドブル_水だけを格納した状態で100円投下した時購入可能なのは水だけであるか()
        {
            
            var redbull = Util.MakeRedBullDrink();
            var water = Util.MakeWaterDrink();

            _アイテムRack.Setアイテム(redbull);
            _アイテムRack.Setアイテム(water);

            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == water.Name).IsTrue();
        }


        [TestMethod]
        public void レッドブルだけを格納した状態で200円投下した時購入可能なのはレッドブルだけであるか()
        {

            var redbull = Util.MakeRedBullDrink();

            _アイテムRack.Setアイテム(redbull);

            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == redbull.Name).IsTrue();
        }




    }
}
