using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;

namespace VendingMachineTests
{
    [TestClass]
    public class Step1Tests
    {

        private 自販機操作 _自販機操作;

        [TestInitialize]
        public void TestIniitialize()
        {
            _自販機操作=new 自販機操作();
        }


        [TestMethod]
        public void _1円玉を入れたら取扱外金として1円がでてくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen1)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(1);
                    }
                )
                ;
        }

        [TestMethod]
        public void _5円玉を入れたら取扱外金として5円がでてくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen5)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(5);
                    }
                )
                ;
        }


        [TestMethod]
        public void _2000円札を入れたら取扱外金として2000円がでてくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen2000)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(2000);
                    }
                )
                ;
        }

        [TestMethod]
        public void _5000円札を入れたら取扱外金として5000円がでてくる()
        {

            _自販機操作
                .お金投入(MoneyKind.Yen5000)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(5000);
                    }
                )
                ;
        }

        [TestMethod]
        public void _10000円札を入れたら取扱外金として10000円がでてくる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen10000)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(10000);
                    }
                )
                ;
        }


        [TestMethod]
        public void _1円玉を5回投入したら取扱外金として5円取得できる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(5);
                    }
                )
                ;

        }


        [TestMethod]
        public void _1円玉を5回投入し5円玉を投入したら取扱外金として10円取得できる()
        {
            _自販機操作
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen1)
                .お金投入(MoneyKind.Yen5)
                .取扱外金取出し
                (
                    取り出した取扱外金 =>
                    {
                        取り出した取扱外金.Get合計金額().Is(10);
                    }
                )
                ;
        }
    }
}
