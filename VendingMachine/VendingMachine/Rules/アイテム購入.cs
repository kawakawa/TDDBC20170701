﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Rules
{
    public static class アイテム購入
    {
        public static bool Is購入可(string 対象ItemName)
        {
            var itemラック = Itemラック.ItemラックFactory();

            //在庫なし=>購入不可
            if (itemラック.GetItemList().All(n => n.Name != 対象ItemName))
                return false;


            var 対象アイテム = itemラック.GetItemList()
                                        .First(n=>n.Name== 対象ItemName);

            var 投入額 = 投入金額.投入金額Factory();
            var 合計投入金額 = 投入額.Get合計金額();

            if (対象アイテム.Price <= 合計投入金額)
                return true;

            return false;
        }
    }
}
