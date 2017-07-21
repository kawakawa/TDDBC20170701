using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step0Tests
    {

        private 投入金 _投入金;
        private 投入口 _投入口;

        [TestInitialize]
        public void TestIniitialize()
        {
            _投入金 = 投入金.Factory();
            _投入金.投入金額歴初期化();
            _投入口 = 投入口.Factory(_投入金);
        }



        [TestMethod]
        public void _10円玉を投入して投入金額合計が10円になる()
        {
            _投入口.投入(MoneyKind.Yen10);
            _投入金.Get合計金額().Is(10);
        }

        [TestMethod]
        public void _50円玉を投入して投入金額が50円になる()
        {
            _投入口.投入(MoneyKind.Yen50);
            _投入金.Get合計金額().Is(50);
        }

        [TestMethod]
        public void _100円玉を投入して投入金額が100円になる()
        {
            _投入口.投入(MoneyKind.Yen100);
            _投入金.Get合計金額().Is(100);
        }

        [TestMethod]
        public void _500円玉を投入して投入金額が500円になる()
        {
            _投入口.投入(MoneyKind.Yen500);
            _投入金.Get合計金額().Is(500);
        }

        [TestMethod]
        public void _1000円札を投入して投入金額が1000円になる()
        {
            _投入口.投入(MoneyKind.Yen1000);
            _投入金.Get合計金額().Is(1000);
        }

        [TestMethod]
        public void _10円玉を5回投入して投入金額が50円になる()
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen10));

            _投入金.Get合計金額().Is(50);
        }

        [TestMethod]
        public void _50円玉を2回投入して投入金額が100円になる()
        {

            Enumerable.Range(1, 2).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen50));

            _投入金.Get合計金額().Is(100);
        }



        [TestMethod]
        public void _100円玉を5回投入して投入金額が500円になる()
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen100));

            _投入金.Get合計金額().Is(500);
        }


        [TestMethod]
        public void _500円玉を2回投入して投入金額が1000円になる()
        {
            Enumerable.Range(1, 2).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen500));

            _投入金.Get合計金額().Is(1000);
        }



        [TestMethod]
        public void _10円玉を投入して払い戻しをすると釣銭10円が戻ってくる()
        {
            _投入口.投入(MoneyKind.Yen10);

            _投入金.払い戻し();

            釣銭口.Factory()
                 .Get釣銭()
                 .Get合計金額().Is(10);
        }


        [TestMethod]
        public void _50円玉を投入して払い戻しをすると釣銭50円が戻ってくる()
        {
            _投入口.投入(MoneyKind.Yen50);

            _投入金.払い戻し();
            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(50);
        }

        [TestMethod]
        public void _10円玉を5回投入して払い戻しをすると釣銭50円が戻ってくる()
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen10));

            _投入金.払い戻し();
            釣銭口.Factory()
                .Get釣銭()
                .Get合計金額().Is(50);
        }

    }
}
