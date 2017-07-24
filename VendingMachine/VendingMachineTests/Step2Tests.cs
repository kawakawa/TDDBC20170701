using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.部位;

namespace VendingMachineTests
{
    [TestClass]
    public class Step2Tests
    {

        private アイテムRack _アイテムRack;

        private readonly Item.Item _coke = Util.MakeCokeDrink();

        [TestInitialize]
        public void TestInitialize()
        {
            _アイテムRack = Util.アイテムRack準備();
        }
        

        [TestMethod]
        public void コーラを1本在庫として格納できる()
        {
            Util.アイテムRackにセット(_coke,1);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(1);
            格納アイテムリスト.First().Name.Is(_coke.Name);
            格納アイテムリスト.First().Price.Is(_coke.Price);
            
        }

        [TestMethod]
        public void コーラを5本在庫として格納できる()
        {
            Util.アイテムRackにセット(_coke,5);

            var 格納アイテムリスト = _アイテムRack.Get格納アイテムリスト();
            格納アイテムリスト.Count().Is(5);
            格納アイテムリスト.All(n => n.Name == _coke.Name).IsTrue();
            格納アイテムリスト.All(n => n.Price == _coke.Price).IsTrue();

        }
    }
}
