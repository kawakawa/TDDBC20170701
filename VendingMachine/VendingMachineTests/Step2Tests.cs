using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class Step2Tests
    {

        private 自販機操作 _自販機操作;

        private readonly Item.Item _coke = Util.MakeCokeDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _自販機操作=new 自販機操作();
        }
        

        [TestMethod]
        public void コーラを1本在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 1)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(1);
                        アイテムリスト.First().Name.Is(_coke.Name);
                    }
                )
                ;
        }

        [TestMethod]
        public void コーラを5本在庫として格納できる()
        {
            _自販機操作
                .アイテムをラックに格納(対象アイテム: _coke, 個数: 5)
                .格納アイテムリスト取得
                (
                    アイテムリスト =>
                    {
                        アイテムリスト.Count().Is(5);
                        アイテムリスト.All(n=>n.Name==_coke.Name).IsTrue();
                    }
                )
                ;


        }
    }
}
