using System.Collections.Generic;
using System.Linq;
using Item.Items;

namespace VendingMachine.部位
{
    public class 操作パネル
    {
        public static void 購入(string 購入希望アイテム名)
        {
            var is購入可 = Rules.アイテム購入可否判定.Is購入可(購入希望アイテム名);

            if(is購入可==false)
                return;

            処理.購入.実行(購入希望アイテム名);

        }


        public static IEnumerable<Item.Item> Get購入可能アイテムリスト()
        {
            var 購入可能アイテムリスト = アイテムRack.Factory()
                                .Get格納アイテムリスト()
                                .Where(n => Rules.アイテム購入可否判定.Is購入可(n.Name))
                                .Select(n => n);

            return 購入可能アイテムリスト;
        }
    }
}
