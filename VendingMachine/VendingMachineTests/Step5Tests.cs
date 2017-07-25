using System;
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
        private 自販機操作 _自販機操作;

        private readonly Item.Item _coke = Util.MakeCokeDrink();
        private readonly Item.Item _redbull = Util.MakeRedBullDrink();
        private readonly Item.Item _water = Util.MakeWaterDrink();


        [TestInitialize]
        public void TestInitialize()
        {
            _自販機操作=new 自販機操作();

            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke,    個数: 5)
                .アイテムをラックに格納(対象アイテム: _redbull, 個数: 5)
                .アイテムをラックに格納(対象アイテム: _water,   個数: 5);
        }



        [TestMethod]
        public void _100円投入してコーラを1本購入した場合_お釣り0円とコーラ在庫4本となるか()
        {
            _自販機操作
                .お金投入(金額: MoneyKind.Yen100)
                .購入(アイテム名:_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(0);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n=>n.Name==_coke.Name).Is(4);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(100);
                    }
                );
        }


        [TestMethod]
        public void _500円投入してコーラを1本購入した場合_お釣り400円とコーラ在庫4本となるか()
        {
            _自販機操作
                .お金投入(金額: MoneyKind.Yen500)
                .購入(アイテム名: _coke.Name)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(400);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _coke.Name).Is(4);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(100);
                    }
                );
            
        }


        [TestMethod]
        public void _500円玉でコーラを5本を購入した場合_お釣り0円とコーラ在庫0本となるか()
        {

            _自販機操作
                .お金投入(金額: MoneyKind.Yen500)
                .繰り返し購入(アイテム名:_coke.Name,購入回数:5)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(0);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _coke.Name).Is(0);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(500);
                    }
                )
                ;
        }


        [TestMethod]
        public void _1000円札でコーラを5本を購入した場合_お釣り500円とコーラ在庫0本となるか()
        {
            _自販機操作
                .お金投入(金額: MoneyKind.Yen1000)
                .繰り返し購入(アイテム名: _coke.Name, 購入回数: 5)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_coke.Name);
                    }
                )
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(500);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _coke.Name).Is(0);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(500);
                    }
                )
                ;
            
        }

        [TestMethod]
        public void _1000円札でレッドブルを5本を購入した場合_お釣り0円とレッドブル在庫0本となるか()
        {

            _自販機操作
                .お金投入(金額: MoneyKind.Yen1000)
                .繰り返し購入(アイテム名: _redbull.Name, 購入回数: 5)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_redbull.Name);
                    }
                )
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(0);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _redbull.Name).Is(0);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(1000);
                    }
                )
                ;
        }


        [TestMethod]
        public void _2000円札でレッドブルを5本を購入した場合_お釣り1000円とレッドブル在庫0本となるか()
        {

            _自販機操作
                .お金投入(金額: MoneyKind.Yen1000)
                .お金投入(金額: MoneyKind.Yen1000)
                .繰り返し購入(アイテム名: _redbull.Name, 購入回数: 5)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_redbull.Name);
                    }
                )
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(1000);
                    }
                )
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _redbull.Name).Is(0);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(1000);
                    }
                )
                ;
        }

        [TestMethod]
        public void _1000円札でコーラ_レッドブル_水を1本ずつを購入した場合_お釣り600円と在庫がそれぞれ4本となるか()
        {
            _自販機操作
                .お金投入(金額: MoneyKind.Yen1000)
                .購入(_coke.Name)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_coke.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(900);
                        取り出した釣銭.釣銭内容.ToList()
                            .ForEach(money => _自販機操作.お金投入(money));
                    }
                )

                .購入(_redbull.Name)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_redbull.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(700);
                        取り出した釣銭.釣銭内容.ToList()
                            .ForEach(money => _自販機操作.お金投入(money));
                    }
                )


                .購入(_water.Name)
                .取出し口から購入アイテム取出し
                (
                    取り出したアイテム =>
                    {
                        取り出したアイテム.IsNotNull();
                        取り出したアイテム.Name.Is(_water.Name);
                    }
                )
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(600);
                    }
                )

                
               
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count(n => n.Name == _coke.Name).Is(4);
                        アイテムリスト.Count(n => n.Name == _redbull.Name).Is(4);
                        アイテムリスト.Count(n => n.Name == _water.Name).Is(4);
                    }
                )
                .売上金取得
                (
                    売上金 =>
                    {
                        売上金.Is(400);
                    }
                )
                ;
        }
    }
}
