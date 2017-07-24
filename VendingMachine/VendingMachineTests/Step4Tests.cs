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

        private readonly Item.Item _coke = Util.MakeCokeDrink();
        private readonly Item.Item _redbull = Util.MakeRedBullDrink();
        private readonly Item.Item _water = Util.MakeWaterDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = Util.アイテムRack準備();


            _投入金 = Util.投入金準備();

            _投入口 = 投入口.Factory(_投入金);
        }


        [TestMethod]
        public void レッドブル１本を在庫として格納できる()
        {
            Util.アイテムRackにセット(_redbull,1);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(_redbull.Name);
            格納アイテムリスト.First().Price.Is(_redbull.Price);
        }


        [TestMethod]
        public void レッドブル5本を在庫として格納できる()
        {
            Util.アイテムRackにセット(_redbull,5);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.First().Name.Is(_redbull.Name);
            格納アイテムリスト.First().Price.Is(_redbull.Price);
        }

        [TestMethod]
        public void 水１本を在庫として格納できる()
        {
            Util.アイテムRackにセット(_water,1);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(_water.Name);
            格納アイテムリスト.First().Price.Is(_water.Price);
        }


        [TestMethod]
        public void 水5本を在庫として格納できる()
        {
            Util.アイテムRackにセット(_water, 5);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.First().Name.Is(_water.Name);
            格納アイテムリスト.First().Price.Is(_water.Price);
        }


        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で100円投下した時購入可能なのはコーラと水だけであるか()
        {

            Util.アイテムRackにセット(_coke,1);
            Util.アイテムRackにセット(_redbull,1);
            Util.アイテムRackにセット(_water,1);

            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();
            購入可能アイテムリスト.Count().Is(2);
            購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
        }

        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で200円投下した時購入可能なのはコーラとレッドブルと水であるか()
        {
            Util.アイテムRackにセット(_coke, 1);
            Util.アイテムRackにセット(_redbull, 1);
            Util.アイテムRackにセット(_water, 1);

            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);
            
            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(3);
            購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsTrue();
            購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
        }



        [TestMethod]
        public void コーラ_レッドブルだけを格納した状態で100円投下した時購入可能なのはコーラだけであるか()
        {

            Util.アイテムRackにセット(_coke,1);
            Util.アイテムRackにセット(_redbull,1);

            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
        }


        [TestMethod]
        public void レッドブル_水だけを格納した状態で100円投下した時購入可能なのは水だけであるか()
        {
            Util.アイテムRackにセット(_redbull,1);
            Util.アイテムRackにセット(_water,1);

            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
        }


        [TestMethod]
        public void レッドブルだけを格納した状態で200円投下した時購入可能なのはレッドブルだけであるか()
        {
            Util.アイテムRackにセット(_redbull,1);

            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);

            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();

            購入可能アイテムリスト.Count().Is(1);
            購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsTrue();
        }




    }
}
