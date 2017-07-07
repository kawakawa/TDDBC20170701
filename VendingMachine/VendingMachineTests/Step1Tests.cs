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
            投入金額.GetTotal().Is(10);
        }
    }
}
