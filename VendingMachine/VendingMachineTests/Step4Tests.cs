using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step4Tests
    {

        private 自販機操作 _自販機操作;

        private readonly Item.Item _coke = Util.MakeCokeDrink();
        private readonly Item.Item _redbull = Util.MakeRedBullDrink();
        private readonly Item.Item _water = Util.MakeWaterDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _自販機操作=new 自販機操作();
        }


        [TestMethod]
        public void レッドブル１本を在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(1);
                        アイテムリスト.All(n => n.Name == _redbull.Name).IsTrue();
                    }
                );

        }


        [TestMethod]
        public void レッドブル5本を在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 5)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(5);
                        アイテムリスト.All(n => n.Name == _redbull.Name).IsTrue();
                    }
                );
        }

        [TestMethod]
        public void 水１本を在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _water, 個数: 1)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(1);
                        アイテムリスト.All(n => n.Name == _water.Name).IsTrue();
                    }
                );
            
        }


        [TestMethod]
        public void 水5本を在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _water, 個数: 5)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(5);
                        アイテムリスト.All(n => n.Name == _water.Name).IsTrue();
                    }
                );

        }


        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で100円投下した時購入可能なのはコーラと水だけであるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _water, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入可能アイテムリスト
                (
                    購入可能アイテムリスト =>
                    {
                        購入可能アイテムリスト.Count().Is(2);
                        購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsFalse();
                    }
                );
        }


        [TestMethod]
        public void コーラ_レッドブル_水を格納した状態で200円投下した時購入可能なのはコーラとレッドブルと水であるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _water, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .購入可能アイテムリスト
                (
                    購入可能アイテムリスト =>
                    {
                        購入可能アイテムリスト.Count().Is(3);
                        購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsTrue();
                    }
                );
        }


        [TestMethod]
        public void コーラ_レッドブルだけを格納した状態で100円投下した時購入可能なのはコーラだけであるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入可能アイテムリスト
                (
                    購入可能アイテムリスト =>
                    {
                        購入可能アイテムリスト.Count().Is(1);
                        購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsFalse();
                        購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsFalse();
                    }
                );

        }


        [TestMethod]
        public void レッドブル_水だけを格納した状態で100円投下した時購入可能なのは水だけであるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .アイテムをラックに格納(対象アイテム: _water, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入可能アイテムリスト
                (
                    購入可能アイテムリスト =>
                    {
                        購入可能アイテムリスト.Count().Is(1);
                        購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsFalse();
                        購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsTrue();
                        購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsFalse();
                    }
                );
        }


        [TestMethod]
        public void レッドブルだけを格納した状態で200円投下した時購入可能なのはレッドブルだけであるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .購入可能アイテムリスト
                (
                    購入可能アイテムリスト =>
                    {
                        購入可能アイテムリスト.Count().Is(1);
                        購入可能アイテムリスト.Any(n => n.Name == _coke.Name).IsFalse();
                        購入可能アイテムリスト.Any(n => n.Name == _water.Name).IsFalse();
                        購入可能アイテムリスト.Any(n => n.Name == _redbull.Name).IsTrue();
                    }
                );


        }
        
        


    }
}
