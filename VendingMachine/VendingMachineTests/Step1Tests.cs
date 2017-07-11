using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {
        [TestMethod]
        public void _10円を投入して投入金額合計が10円になる()
        {
            投入口.投入(MoneyKind.Yen10);
            投入金額.Get合計金額().Is(10);
        }

        [TestMethod]
        public void _50円を投入して投入金額が50円になる()
        {
            投入口.投入(MoneyKind.Yen50);
            投入金額.Get合計金額().Is(50);
        }


    }
}
