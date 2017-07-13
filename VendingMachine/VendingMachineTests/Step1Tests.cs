using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {

        private 投入金額 _投入金額;
        private 投入口 _投入口;

        [TestInitialize]
        public void TestIniitialize()
        {
            _投入金額 = 投入金額.投入金額Factory();
            _投入金額.初期化();
            _投入口 = 投入口.投入口Factory(_投入金額);
        }


        [TestMethod]
        public void _1円玉を入れたらそのまま釣銭として1円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen1);

            var 取扱外金 = _投入口.Get取扱外金();
            取扱外金.Value.Is(1);
        }

        [TestMethod]
        public void _5円玉を入れたらそのまま釣銭として5円がでてくる()
        {
            _投入口.投入(MoneyKind.Yen5);

            var 取扱外金 = _投入口.Get取扱外金();
            取扱外金.Value.Is(5);
        }
    }
}
