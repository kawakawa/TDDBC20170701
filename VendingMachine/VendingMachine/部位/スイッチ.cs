namespace VendingMachine.部位
{
    public class スイッチ
    {
        public static void 購入(string 購入希望アイテム名)
        {
            var is購入可 = Rules.アイテム購入可否判定.Is購入可(購入希望アイテム名);

            if(is購入可==false)
                return;

            処理.購入.実行(購入希望アイテム名);

        }
    }
}
