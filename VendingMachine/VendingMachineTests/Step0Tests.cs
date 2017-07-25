using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step0Tests
    {

        private 自販機操作 _自販機操作;

        [TestInitialize]
        public void TestIniitialize()
        {
            _自販機操作=new 自販機操作();
        }



        [TestMethod]
        public void _10円玉を投入して投入金額合計が10円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen10)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(10);
                    }
                );
        }

        [TestMethod]
        public void _50円玉を投入して投入金額が50円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen50)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(50);
                    }
                );
        }

        [TestMethod]
        public void _100円玉を投入して投入金額が100円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen100)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(100);
                    }
                );
        }

        [TestMethod]
        public void _500円玉を投入して投入金額が500円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen500)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(500);
                    }
                );
        }

        [TestMethod]
        public void _1000円札を投入して投入金額が1000円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen1000)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(1000);
                    }
                );
        }

        [TestMethod]
        public void _10円玉を5回投入して投入金額が50円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(50);
                    }
                );
        }

        [TestMethod]
        public void _50円玉を2回投入して投入金額が100円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen50)
                .お金投入(MoneyKind.Yen50)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(100);
                    }
                );
        }



        [TestMethod]
        public void _100円玉を5回投入して投入金額が500円になる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .お金投入(MoneyKind.Yen100)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(500);
                    }
                );
        }


        [TestMethod]
        public void _500円玉を2回投入して投入金額が1000円になる()
        {

            _自販機操作
                .お金投入(MoneyKind.Yen500)
                .お金投入(MoneyKind.Yen500)
                .投入金
                (
                    投入金額 =>
                    {
                        投入金額.Get合計金額().Is(1000);
                    }
                );
        }



        [TestMethod]
        public void _10円玉を投入して払い戻しをすると釣銭10円が戻ってくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen10)
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(10);
                    }
                );
        }


        [TestMethod]
        public void _50円玉を投入して払い戻しをすると釣銭50円が戻ってくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen50)
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(50);
                    }
                );
        }

        [TestMethod]
        public void _10円玉を5回投入して払い戻しをすると釣銭50円が戻ってくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .お金投入(MoneyKind.Yen10)
                .払い戻し()
                .釣銭取出し
                (
                    取り出した釣銭 =>
                    {
                        取り出した釣銭.Get合計金額().Is(50);
                    }
                );
        }

    }
}
