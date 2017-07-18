namespace VendingMachine
{
    public class アイテム受取口
    {

        private static アイテム受取口 _アイテム受取口;


        private アイテム受取口()
        {
        }
        

        public static アイテム受取口 アイテム受取口Factory()
        {
            return _アイテム受取口 ?? (_アイテム受取口 = new アイテム受取口());
        }


        public Item.Item Getアイテム()
        {
            var coke = Item.Items.Drink.Factory("コーラ", 100);
            return coke;
        }
    }
}
