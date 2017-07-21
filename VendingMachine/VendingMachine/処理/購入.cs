﻿using VendingMachine.部位;

namespace VendingMachine.処理
{
    public static class 購入
    {
        public static void 実行(string 購入対象アイテム)
        {

            //アイテム在庫整理
            var 購入アイテム=アイテムRack.Factory()
                                      .アイテム取出し(購入対象アイテム);
            
            //購入アイテムを受取口にセット
            アイテム受取口.Factory()
                .Setアイテム(購入アイテム);
            
            //売上計上
            売上金.Factory()
                .Add売上金(購入アイテム.Price);

            //投入金額計算
            投入金.Factory()
                .購入金額分減算(購入アイテム.Price)
                .払い戻し();
        }
    }
}
