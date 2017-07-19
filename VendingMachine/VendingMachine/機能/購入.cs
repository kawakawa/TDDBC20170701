﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.機能
{
    public static class 購入
    {
        public static void 実行(string 購入対象アイテム)
        {

            //アイテム在庫整理
            var item = Item.Items.Drink.Factory("コーラ", 100);


            アイテム受取口.アイテム受取口Factory()
                .Setアイテム(item);

            //売上計上
            売上金額管理.売上金額管理Factory()
                .Add売上金(item.Price);

            //投入金額整理
            投入金額管理.投入金額Factory()
                .購入金額分減算(item.Price)
                .払い戻し();
        }
    }
}
