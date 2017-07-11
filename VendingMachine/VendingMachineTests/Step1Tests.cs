using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;
using Money = Money.Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {
        [TestMethod]
        public void _10円玉を投入して投入金額合計が10円になる()
        {
            投入金額.初期化();
            投入口.投入(MoneyKind.Yen10);
            投入金額.Get合計金額().Is(10);
        }

        [TestMethod]
        public void _50円玉を投入して投入金額が50円になる()
        {
            投入金額.初期化();
            投入口.投入(MoneyKind.Yen50);
            投入金額.Get合計金額().Is(50);
        }

        [TestMethod]
        public void _100円玉を投入して投入金額が100円になる()
        {
            投入金額.初期化();
            投入口.投入(MoneyKind.Yen100);
            投入金額.Get合計金額().Is(100);
        }

        [TestMethod]
        public void _500円玉を投入して投入金額が500円になる()
        {
            投入金額.初期化();
            投入口.投入(MoneyKind.Yen500);
            投入金額.Get合計金額().Is(500);
        }

        [TestMethod]
        public void _1000円札を投入して投入金額が1000円になる()
        {
            投入金額.初期化();
            投入口.投入(MoneyKind.Yen1000);
            投入金額.Get合計金額().Is(1000);
        }

        [TestMethod]
        public void _10円玉を5回投入して投入金額が50円になる()
        {
            投入金額.初期化();

            Enumerable.Range(1, 5).ToList()
                .ForEach(i => 投入口.投入(MoneyKind.Yen10));

            投入金額.Get合計金額().Is(50);
        }

        [TestMethod]
        public void _50円玉を2回投入して投入金額が100円になる()
        {
            投入金額.初期化();

            Enumerable.Range(1, 2).ToList()
                .ForEach(i => 投入口.投入(MoneyKind.Yen50));

            投入金額.Get合計金額().Is(100);
        }



        [TestMethod]
        public void _100円玉を5回投入して投入金額が500円になる()
        {
            投入金額.初期化();

            Enumerable.Range(1, 5).ToList()
                .ForEach(i => 投入口.投入(MoneyKind.Yen100));

            投入金額.Get合計金額().Is(500);
        }


        [TestMethod]
        public void _500円玉を2回投入して投入金額が1000円になる()
        {
            投入金額.初期化();

            Enumerable.Range(1, 2).ToList()
                .ForEach(i => 投入口.投入(MoneyKind.Yen500));

            投入金額.Get合計金額().Is(1000);
        }


    }
}
