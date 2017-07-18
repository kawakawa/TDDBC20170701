using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step3Tests
    {

        private Itemラック _itemラック;
        private 投入金額管理 _投入金額管理;
        private 投入口 _投入口;

        private Item.Item _coke;

        [TestInitialize]
        public void TestInitialize()
        {
            _coke= MakeCokeDrink();

            _itemラック = Itemラック.ItemラックFactory();
            _itemラック.格納アイテム初期化();

            _投入金額管理= 投入金額管理.投入金額Factory();
            _投入金額管理.投入金額歴初期化();

            _投入口= 投入口.投入口Factory(_投入金額管理);
        }

        
        public static Item.Item MakeCokeDrink()
        {
            return Item.Items.Drink.Factory("コーラ", 100);
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で100円投入して購入可能状態となるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);

            VendingMachine.Rules.アイテム購入
                                .Is購入可(_coke.Name)
                                .IsTrue();
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で10円投入して購入不可状態となるか()
        {
            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen10);

            VendingMachine.Rules.アイテム購入
                .Is購入可(_coke.Name)
                .IsFalse();
        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円投入して購入不可状態となるか()
        {
            //お金投入
            _投入口.投入(MoneyKind.Yen100);

            //コーラ在庫は未セット

            VendingMachine.Rules.アイテム購入
                .Is購入可(_coke.Name)
                .IsFalse();
        }


        [TestMethod]
        public void _100円コーラの在庫がある状態で100円で購入してコーラと釣銭0円が取得できるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);


            スイッチ.購入(_coke.Name);

            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム().Name.Is(_coke.Name);

            釣銭口.釣銭口Factory()
                .Get釣銭()
                .Get合計金額().Is(0);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で10円で購入してコーラは取得できない()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen10);


            スイッチ.購入(_coke.Name);


            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム()
                .IsNull();

        }

        [TestMethod]
        public void _100円コーラの在庫がない状態で100円で購入してコーラは取得できない()
        {

            //ラックにcoke未格納

            //お金投入
            _投入口.投入(MoneyKind.Yen100);


            スイッチ.購入(_coke.Name);


            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム().IsNull();

        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で110円で購入してコーラと釣銭10円が取得できるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen10);


            スイッチ.購入(_coke.Name);

            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム().Name.Is(_coke.Name);

            釣銭口.釣銭口Factory()
                .Get釣銭()
                .Get合計金額().Is(10);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で200円で購入してコーラと釣銭100円が取得できるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen100);


            スイッチ.購入(_coke.Name);

            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム().Name.Is(_coke.Name);

            釣銭口.釣銭口Factory()
                .Get釣銭()
                .Get合計金額().Is(100);
        }

        [TestMethod]
        public void _100円コーラの在庫がある状態で180円で購入してコーラと釣銭80円が取得できるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);
            _投入口.投入(MoneyKind.Yen50);
            _投入口.投入(MoneyKind.Yen10);
            _投入口.投入(MoneyKind.Yen10);
            _投入口.投入(MoneyKind.Yen10);


            スイッチ.購入(_coke.Name);

            アイテム受取口
                .アイテム受取口Factory()
                .Getアイテム().Name.Is(_coke.Name);

            釣銭口.釣銭口Factory()
                .Get釣銭()
                .Get合計金額().Is(80);
        }



        [TestMethod]
        public void _100円コーラの在庫がある状態で1本購入して売上金額が100円となるか()
        {

            //ラックにcoke格納
            _itemラック.Setアイテム(_coke);

            //お金投入
            _投入口.投入(MoneyKind.Yen100);


            スイッチ.購入(_coke.Name);

            売上金額管理.売上金額管理Factory()
                .GetTotal売上金額()
                .Is(_coke.Price);

        }


    }
}
