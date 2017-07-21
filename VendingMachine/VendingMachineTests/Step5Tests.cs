using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;
using Money = Money.Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step5Tests
    {
        private アイテムRack _アイテムRack;
        private 投入金 _投入金;
        private 投入口 _投入口;

        private Item.Item _coke;
        private Item.Item _redbull;
        private Item.Item _water;


        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = アイテムRack.Factory();
            _アイテムRack.格納アイテム初期化();
            
            _投入金 = 投入金.投入金額Factory();
            _投入金.投入金額歴初期化();

            _投入口 = 投入口.Factory(_投入金);


            //Cokeを5本ラック格納
            _coke = Util.MakeCokeDrink();
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _アイテムRack.Setアイテム(_coke));

            //レッドブルを5本ラック格納
            _redbull = Util.MakeRedBullDrink();
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _アイテムRack.Setアイテム(_redbull));

            //水を5本ラック格納
            _water = Util.MakeWaterDrink();
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _アイテムRack.Setアイテム(_water));
            
        }



        [TestMethod]
        public void _100円投入してコーラを1本購入した場合_お釣り0円とコーラ在庫4本となるか()
        {
            _投入口.投入(MoneyKind.Yen100);

            操作パネル.購入(_coke.Name);

            アイテム受取口
                .Factory()
                .Getアイテム().Name.Is(_coke.Name);


            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(0);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name==_coke.Name).Is(4);
        }


        [TestMethod]
        public void _500円投入してコーラを1本購入した場合_お釣り400円とコーラ在庫4本となるか()
        {
            _投入口.投入(MoneyKind.Yen500);
            
            操作パネル.購入(_coke.Name);

            アイテム受取口
                .Factory()
                .Getアイテム().Name.Is(_coke.Name);


            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(400);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(4);
        }


        [TestMethod]
        public void _500円玉でコーラを5本を購入した場合_お釣り0円とコーラ在庫0本となるか()
        {
            _投入口.投入(MoneyKind.Yen500);

            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {

                    操作パネル.購入(_coke.Name);

                    アイテム受取口
                        .Factory()
                        .Getアイテム().Name.Is(_coke.Name);

                    //お釣りを再度投入
                    釣銭口.Factory()
                        .Get釣銭()
                        .Get釣銭内容().ToList()
                        .ForEach(money => _投入口.投入(money));
                });
            
            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(0);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(0);
        }





    }
}
