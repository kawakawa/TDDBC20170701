
namespace VendingMachine
{
    public class アイテム受取口
    {

        private static アイテム受取口 _アイテム受取口;


        private Item.Item _購入アイテム;

        private アイテム受取口()
        {
        }
        

        public static アイテム受取口 アイテム受取口Factory()
        {
            return _アイテム受取口 ?? (_アイテム受取口 = new アイテム受取口());
        }


        public Item.Item Getアイテム()
        {
            var 受取用アイテム = _購入アイテム;
           購入アイテム初期化();
            return 受取用アイテム;
        }

        private void 購入アイテム初期化()
        {
            _購入アイテム = null;
        }

        public void Setアイテム(Item.Item 購入アイテム)
        {
            _購入アイテム = 購入アイテム;
        }
    }
}
