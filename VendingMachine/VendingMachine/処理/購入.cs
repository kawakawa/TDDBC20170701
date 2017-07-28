using VendingMachine.部位;

namespace VendingMachine.処理
{
    public static class 購入
    {
        public static void 実行(string 購入対象アイテム)
        {
            var 購入アイテム = ラックから対象アイテム取出し(購入対象アイテム);
            
            購入アイテムを受取口にセット(購入アイテム);
            
            売上金にアイテム金額を計上(購入アイテム);

            投入金から購入金額の差分を払い戻し(購入アイテム);
        }


        private static void 投入金から購入金額の差分を払い戻し(Item.Item 購入アイテム)
        {
            投入金.Factory()
                .購入金額分減算(購入アイテム.Price)
                .払い戻し();
        }

        private static void 売上金にアイテム金額を計上(Item.Item 購入アイテム)
        {
            売上金.Factory()
                .Add売上金(購入アイテム.Price);
        }

        private static void 購入アイテムを受取口にセット(Item.Item 購入アイテム)
        {
            アイテム受取口.Factory()
                .Setアイテム(購入アイテム);
        }


        private static Item.Item ラックから対象アイテム取出し(string 購入対象アイテム)
        {
            var 購入アイテム = アイテムRack.Factory()
                .アイテム取出し(購入対象アイテム);
            return 購入アイテム;
        }
    }
}
