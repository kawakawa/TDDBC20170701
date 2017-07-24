using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step5Tests
    {
        private アイテムRack _アイテムRack;
        private 投入金 _投入金;
        private 投入口 _投入口;

        private 売上金 _売上金;

        private readonly Item.Item _coke = Util.MakeCokeDrink();
        private readonly Item.Item _redbull = Util.MakeRedBullDrink();
        private readonly Item.Item _water = Util.MakeWaterDrink();


        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = Util.アイテムRack準備();
            
            _投入金 = Util.投入金準備();
            _売上金 = Util.売上金準備();

            _投入口 = 投入口.Factory(_投入金);


            //Cokeを5本ラック格納
            Util.アイテムRackにセット(_coke,5);

            //レッドブルを5本ラック格納
            Util.アイテムRackにセット(_redbull, 5);

            //水を5本ラック格納
            Util.アイテムRackにセット(_water, 5);
        }



        [TestMethod]
        public void _100円投入してコーラを1本購入した場合_お釣り0円とコーラ在庫4本となるか()
        {
            _投入口.投入(MoneyKind.Yen100);

            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);


            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(0);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name==_coke.Name).Is(4);


            _売上金.GetTotal売上金額().Is(100);
        }


        [TestMethod]
        public void _500円投入してコーラを1本購入した場合_お釣り400円とコーラ在庫4本となるか()
        {
            _投入口.投入(MoneyKind.Yen500);
            
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);


            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(400);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(4);


            _売上金.GetTotal売上金額().Is(100);
        }


        [TestMethod]
        public void _500円玉でコーラを5本を購入した場合_お釣り0円とコーラ在庫0本となるか()
        {
            _投入口.投入(MoneyKind.Yen500);

            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {

                    操作パネル.購入(_coke.Name);

                    Util.受取口からアイテム取出し()
                            .Name.Is(_coke.Name);

                    //お釣りを再度投入
                    釣銭口.Factory()
                        .Get釣銭()
                        .釣銭内容.ToList()
                        .ForEach(money => _投入口.投入(money));
                });
            
            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(0);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(0);


            _売上金.GetTotal売上金額().Is(500);
        }


        [TestMethod]
        public void _1000円札でコーラを5本を購入した場合_お釣り500円とコーラ在庫0本となるか()
        {
            _投入口.投入(MoneyKind.Yen1000);

            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {

                    操作パネル.購入(_coke.Name);

                    Util.受取口からアイテム取出し()
                    .Name.Is(_coke.Name);

                    //お釣りを再度投入
                    釣銭口.Factory()
                        .Get釣銭()
                        .釣銭内容.ToList()
                        .ForEach(money => _投入口.投入(money));
                });


            操作パネル.払戻し();

            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(500);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(0);

            _売上金.GetTotal売上金額().Is(500);
        }

        [TestMethod]
        public void _1000円札でレッドブルを5本を購入した場合_お釣り0円とレッドブル在庫0本となるか()
        {
            _投入口.投入(MoneyKind.Yen1000);

            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {

                    操作パネル.購入(_redbull.Name);

                    Util.受取口からアイテム取出し()
                    .Name.Is(_redbull.Name);

                    //お釣りを再度投入
                    釣銭口.Factory()
                        .Get釣銭()
                        .釣銭内容.ToList()
                        .ForEach(money => _投入口.投入(money));
                });


            操作パネル.払戻し();

            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(0);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _redbull.Name).Is(0);

            _売上金.GetTotal売上金額().Is(1000);
        }


        [TestMethod]
        public void _2000円札でレッドブルを5本を購入した場合_お釣り1000円とレッドブル在庫0本となるか()
        {
            _投入口.投入(MoneyKind.Yen1000);
            _投入口.投入(MoneyKind.Yen1000);

            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {

                    操作パネル.購入(_redbull.Name);

                    Util.受取口からアイテム取出し()
                    .Name.Is(_redbull.Name);

                    //お釣りを再度投入
                    釣銭口.Factory()
                        .Get釣銭()
                        .釣銭内容.ToList()
                        .ForEach(money => _投入口.投入(money));
                });


            操作パネル.払戻し();

            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(1000);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count(n => n.Name == _redbull.Name).Is(0);

            _売上金.GetTotal売上金額().Is(1000);
        }

        [TestMethod]
        public void _1000円札でコーラ_レッドブル_水を1本ずつを購入した場合_お釣り600円と在庫がそれぞれ4本となるか()
        {
            _投入口.投入(MoneyKind.Yen1000);


            //コーラ購入
            操作パネル.購入(_coke.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_coke.Name);

            //お釣りを再度投入
            釣銭口.Factory()
                .Get釣銭()
                .釣銭内容.ToList()
                .ForEach(money => _投入口.投入(money));


            //レッドブル購入
            操作パネル.購入(_redbull.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_redbull.Name);
            
            //お釣りを再度投入
            釣銭口.Factory()
                .Get釣銭()
                .釣銭内容.ToList()
                .ForEach(money => _投入口.投入(money));


            //水購入
            操作パネル.購入(_water.Name);

            Util.受取口からアイテム取出し()
                .Name.Is(_water.Name);

            //お釣りを再度投入
            釣銭口.Factory()
                .Get釣銭()
                .釣銭内容.ToList()
                .ForEach(money => _投入口.投入(money));
            
            
            操作パネル.払戻し();

            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(600);


            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();

            格納アイテムリスト.Count(n => n.Name == _coke.Name).Is(4);
            格納アイテムリスト.Count(n => n.Name == _redbull.Name).Is(4);
            格納アイテムリスト.Count(n => n.Name == _water.Name).Is(4);

            _売上金.GetTotal売上金額().Is(400);
        }


    }
}
