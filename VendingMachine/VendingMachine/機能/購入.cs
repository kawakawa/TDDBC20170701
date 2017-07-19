using System;
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
            var 購入アイテム=Itemラック.ItemラックFactory()
                                      .アイテム取出し(購入対象アイテム);
            
            //購入アイテムを受取口にセット
            アイテム受取口.アイテム受取口Factory()
                .Setアイテム(購入アイテム);
            
            //売上計上
            売上金額管理.売上金額管理Factory()
                .Add売上金(購入アイテム.Price);

            //投入金額計算
            投入金額管理.投入金額Factory()
                .購入金額分減算(購入アイテム.Price)
                .払い戻し();
        }
    }
}
