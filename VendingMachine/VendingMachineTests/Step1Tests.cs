using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {

        private 投入金 _投入金;
        private 投入口 _投入口;
        private 釣銭口 _釣銭口;

        [TestInitialize]
        public void TestIniitialize()
        {
            _投入金 = Util.投入金準備();
            _投入口 = 投入口.Factory(_投入金);
            _釣銭口 = 釣銭口.Factory();
        }


        [TestMethod]
        public void _1円玉を入れたら取扱外金として1円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen1);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(1);
        }

        [TestMethod]
        public void _5円玉を入れたら取扱外金として5円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen5);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(5);
        }


        [TestMethod]
        public void _2000円札を入れたら取扱外金として2000円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen2000);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(2000);
        }

        [TestMethod]
        public void _5000円札を入れたら取扱外金として5000円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen5000);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(5000);
        }

        [TestMethod]
        public void _10000円札を入れたら取扱外金として10000円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen10000);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(10000);
        }


        [TestMethod]
        public void _1円玉を5回投入したら取扱外金として5円取得できる()
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen1));

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(5);
        }


        [TestMethod]
        public void _1円玉を5回投入し5円玉を投入したら取扱外金として10円取得できる()
        {
            Enumerable.Range(1, 5).ToList()
                .ForEach(i => _投入口.投入(MoneyKind.Yen1));

            _投入口.投入(MoneyKind.Yen5);

            var 取扱外金 = _釣銭口.Get取扱外金();
            取扱外金.Get合計金額().Is(10);
        }
    }
}
