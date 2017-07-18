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

            //アイテム在庫整理
            var item = Item.Items.Drink.Factory("コーラ", 100);
            アイテム受取口.アイテム受取口Factory()
                         .Setアイテム(item);

            //投入金額整理
            投入金額管理.投入金額Factory()
                        .購入金額分減算(item.Price)
                        .払い戻し();


        }
    }
}
