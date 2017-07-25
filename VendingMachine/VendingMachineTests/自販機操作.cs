using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    public class 自販機操作
    {

        private readonly アイテムRack _アイテムRack;
        private readonly 投入金 _投入金;
        private readonly 投入口 _投入口;
        private readonly 売上金 _売上金;



        public 自販機操作()
        {
            _アイテムRack = Util.アイテムRack準備();

            _投入金 = Util.投入金準備();
            _売上金 = Util.売上金準備();

            _投入口 = 投入口.Factory(_投入金);
        }


        public 自販機操作 アイテムをラックに格納(Item.Item 対象アイテム, int 個数)
        {
            Util.アイテムRackにセット(対象アイテム,個数);
            return this;
        }

        public 自販機操作 お金投入(Money.Money 金額)
        {
            _投入口.投入(金額);
            return this;
        }

        public 自販機操作 購入可能アイテムリスト(Action<IEnumerable<Item.Item>> action)
        {
            var 購入可能アイテムリスト = 操作パネル.Get購入可能アイテムリスト();
            action(購入可能アイテムリスト);
            return this;
        }


        public 自販機操作 購入(string アイテム名)
        {
            操作パネル.購入(アイテム名);
            return this;
        }

        public 自販機操作 繰り返し購入(string アイテム名, int 購入回数)
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i =>
                {
                    操作パネル.購入(アイテム名);

                    //お釣りを再度投入
                    Util.釣銭取出し()
                        .釣銭内容.ToList()
                        .ForEach(money => _投入口.投入(money));
                });
            return this;
        }


        public 自販機操作 取出し口から購入アイテム取出し(Action<Item.Item> action)
        {
            var 取り出したアイテム = Util.受取口からアイテム取出し();
            action(取り出したアイテム);
            return this;
        }

        public 自販機操作 払い戻し()
        {
            操作パネル.払戻し();
            return this;
        }

        public 自販機操作 釣銭取出し(Action<釣銭> action)
        {
            var 取り出した釣銭= Util.釣銭取出し();
            action(取り出した釣銭);
            return this;
        }


        public 自販機操作 格納アイテムリスト取得(Action<IEnumerable<Item.Item>> action)
        {
            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            action(格納アイテムリスト);
            return this;
        }

        public 自販機操作 売上金取得(Action<int> action)
        {
            var 売上金=_売上金.GetTotal売上金額();
            action(売上金);

            return this;
        }


        public 自販機操作 説明コメント(string コメント)
        {
            return this;
        }
    }
}
