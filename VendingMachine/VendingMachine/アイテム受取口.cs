namespace VendingMachine
{
    public class アイテム受取口
    {
        public static Item.Item Getアイテム()
        {
            var coke = Item.Items.Drink.Factory("コーラ", 100);
            return coke;
        }
    }
}
