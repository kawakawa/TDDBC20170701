using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {
        [TestMethod]
        public void _10円を投入して投入金額合計が10円になる()
        {
            //10円
            var yen10 = new Money(10, MoneyType.Coin);

            投入口.投入(yen10);
            投入金額.Get合計金額().Is(10);
        }

        [TestMethod]
        public void _50円を投入して投入金額が50円になる()
        {
            var yen50=new Money(50,MoneyType.Coin);
            投入口.投入(yen50);
            投入金額.Get合計金額().Is(50);
        }


    }
}
