using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step3Tests
    {

        private アイテムRack _アイテムRack;
        private 投入金 _投入金;
        private 投入口 _投入口;
        private 売上金 _売上金;

        private readonly Item.Item _coke = Util.MakeCokeDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = Util.アイテムRack準備();

            _投入金 = Util.投入金準備();

            _売上金 = Util.売上金準備();

            _投入口= 投入口.Factory(_投入金);
        }
        


        [TestMethod]
        public void _100円コーラの在庫がある状態で100円投入して購入可能状態となるか()
        {
            Util.アイテムRackにセット(_coke,1);

            _投入口.投入(MoneyKind.Yen100);

            VendingMachine.Rules.アイテム購入可否判定
                                .Is購入可(_coke.Name)
                                .IsTrue();
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で10円投入して購入不可状態となるか()
        {
            Util.アイテムRackにセット(_coke,1);

            _投入口.投入(MoneyKind.Yen10);

            VendingMachine.Rules.アイテム購入可否判定
                .Is購入可(_coke.Name)
                .IsFalse();
        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円投入して購入不可状態となるか()
        {
            //お金投入
            _投入口.投入(MoneyKind.Yen100);

            //コーラ在庫は未セット

            //購入可否判定
            VendingMachine.Rules.アイテム購入可否判定
                .Is購入可(_coke.Name)
                .IsFalse();
        }


        [TestMethod]
        public void _100円コーラの在庫がある状態で100円で購入してコーラと釣銭0円が取得できるか()
        {
            Util.アイテムRackにセット(_coke,1);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);

            //購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);

            Util.釣銭取出し()
                .Get合計金額().Is(0);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で10円で購入してコーラは取得できない()
        {
            Util.アイテムRackにセット(_coke,1);

            //お金投入
            _投入口.投入(MoneyKind.Yen10);

            //購入
            操作パネル.購入(_coke.Name);

            //アイテム受取
            Util.受取口からアイテム取出し()
                .IsNull();

        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円で購入してコーラは取得できない()
        {

            //ラックにcoke未格納

            //お金投入
            _投入口.投入(MoneyKind.Yen100);

            //購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .IsNull();

        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で110円で購入してコーラと釣銭10円が取得できるか()
        {
            Util.アイテムRackにセット(_coke,1);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen10);

            //購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);

            Util.釣銭取出し()
                .Get合計金額().Is(10);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で200円で購入してコーラと釣銭100円が取得できるか()
        {
            Util.アイテムRackにセット(_coke, 1);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);

            //購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);

            Util.釣銭取出し()
                .Get合計金額().Is(100);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で180円で購入してコーラと釣銭80円が取得できるか()
        {
            Util.アイテムRackにセット(_coke, 1);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen50);
            _投入口.投入(MoneyKind.Yen10);
            _投入口.投入(MoneyKind.Yen10);
            _投入口.投入(MoneyKind.Yen10);

            //購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);

            Util.釣銭取出し()
                .Get合計金額().Is(80);
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で1本購入して売上金額が100円となるか()
        {
            Util.アイテムRackにセット(_coke,1);
            
            //購入
            _投入口.投入(MoneyKind.Yen100);
            操作パネル.購入(_coke.Name);

            //売上金
            _売上金.GetTotal売上金額()
                        .Is(_coke.Price);
        }


        [TestMethod]
        public void _100円コーラの在庫がある状態で2本購入して売上金額が200円となるか()
        {
            Util.アイテムRackにセット(_coke,2);

            //購入１
            _投入口.投入(MoneyKind.Yen100);
            操作パネル.購入(_coke.Name);

            //購入２
            _投入口.投入(MoneyKind.Yen100);
            操作パネル.購入(_coke.Name);

            //売上金
            _売上金.GetTotal売上金額()
                        .Is(_coke.Price*2);
        }

        [TestMethod]
        public void _100円コーラの在庫が1本の状態で1本購入すると在庫が0本になるか()
        {

            Util.アイテムRackにセット(_coke, 1);

            //購入１
            _投入口.投入(MoneyKind.Yen100);
            操作パネル.購入(_coke.Name);

            //在庫
            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(0);
        }


        [TestMethod]
        public void _100円コーラの在庫が2本の状態で1本購入すると在庫が1本になるか()
        {

            Util.アイテムRackにセット(_coke, 2);

            //購入１
            _投入口.投入(MoneyKind.Yen100);
            操作パネル.購入(_coke.Name);

            //在庫
            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
        }
    }
}
