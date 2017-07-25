using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step3Tests
    {
        private 自販機操作 _自販機操作;
        private readonly Item.Item _coke = Util.MakeCokeDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _自販機操作=new 自販機操作();
        }
        


        [TestMethod]
        public void _100円コーラの在庫がある状態で100円投入して購入可能状態となるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム:_coke,個数:1)
                .お金投入(MoneyKind.Yen100)
                ;
            
            VendingMachine
                .Rules.アイテム購入可否判定
                .Is購入可(_coke.Name)
                .IsTrue();
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で10円投入して購入不可状態となるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen10)
                ;

            VendingMachine.Rules.アイテム購入可否判定
                .Is購入可(_coke.Name)
                .IsFalse();
        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円投入して購入不可状態となるか()
        {
            _自販機操作
                .説明コメント("ラックにアイテムは未格納")
                .お金投入(MoneyKind.Yen100);

            //購入可否判定
            VendingMachine.Rules.アイテム購入可否判定
                .Is購入可(_coke.Name)
                .IsFalse();
        }


        [TestMethod]
        public void _100円コーラの在庫がある状態で100円で購入してコーラと釣銭0円が取得できるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(0);
                    }
                )
                ;
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で10円で購入してコーラは取得できない()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen10)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.IsNull();
                    }
                )
                ;
        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円で購入してコーラは取得できない()
        {
            _自販機操作
                .説明コメント("ラックにアイテムは未格納")
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.IsNull();
                    }
                )
                ;
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で110円で購入してコーラと釣銭10円が取得できるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen10)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(10);
                    }
                )
                ;
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で200円で購入してコーラと釣銭100円が取得できるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(100);
                    }
                )
                ;

        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で180円で購入してコーラと釣銭80円が取得できるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen50)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(80);
                    }
                )
                ;
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で1本購入して売上金額が100円となるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(_coke.Price);
                    }
                )
                ;
        }


        [TestMethod]
        public void _100円コーラの在庫がある状態で2本購入して売上金額が200円となるか()
        {

            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 2)
                .説明コメント("1本目購入")
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .説明コメント("２本目購入")
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(_coke.Price*2);
                    }
                )
                ;
        }

        [TestMethod]
        public void _100円コーラの在庫が1本の状態で1本購入すると在庫が0本になるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(0);
                    }
                )
                ;
        }


        [TestMethod]
        public void _100円コーラの在庫が2本の状態で1本購入すると在庫が1本になるか()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 2)
                .お金投入(MoneyKind.Yen100)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    購入アイテム =>
                    {
                        購入アイテム.Name.Is(_coke.Name);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(1);
                    }
                )
                ;
            
        }
    }
}
