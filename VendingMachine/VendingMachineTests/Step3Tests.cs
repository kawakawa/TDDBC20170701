using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class Step3Tests
    {
        [TestMethod]
        public void コーラの在庫がある状態で100円投入して購入可能状態となるか()
        {
            var coke= Item.Items.Drink.Factory("コーラ", 100);
            var itemラック = Itemラック.ItemラックFactory();
            itemラック.格納アイテム初期化();
            //ラックにcoke格納
            itemラック.SetItem(coke);


            var factory = 投入金額.投入金額Factory();
            factory.投入金額歴初期化();
            var _投入口 = 投入口.投入口Factory(factory);
            _投入口.投入(MoneyKind.Yen100);

            VendingMachine.Rules.アイテム購入.Is購入可(coke.Name).IsTrue();
        }



        [TestMethod]
        public void コーラの在庫がある状態で10円投入して購入不可状態となるか()
        {
            var coke = Item.Items.Drink.Factory("コーラ", 100);
            var itemラック = Itemラック.ItemラックFactory();
            itemラック.格納アイテム初期化();
            //ラックにcoke格納
            itemラック.SetItem(coke);


            var factory = 投入金額.投入金額Factory();
            factory.投入金額歴初期化();
            var _投入口 = 投入口.投入口Factory(factory);
            _投入口.投入(MoneyKind.Yen10);

            VendingMachine.Rules.アイテム購入.Is購入可(coke.Name).IsFalse();
        }


    }
}
