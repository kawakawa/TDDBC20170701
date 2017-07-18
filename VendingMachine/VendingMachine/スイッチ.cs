using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class スイッチ
    {
        public static void 購入(string 購入希望アイテム名)
        {
            var 購入可否 = VendingMachine.Rules.アイテム購入.Is購入可(購入希望アイテム名);

            if(購入可否==false)
                return;

            var coke = Item.Items.Drink.Factory("コーラ", 100);

            アイテム受取口.アイテム受取口Factory()
                         .Setアイテム(coke);

        }
    }
}
