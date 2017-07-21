using Item.Items;

namespace VendingMachineTests
{
    public class Util
    {
        public static Item.Item MakeCokeDrink()
        {
            return Drink.Factory("コーラ", 100);
        }

        public static Item.Item MakeRedBullDrink()
        {
            return Drink.Factory("レッドブル", 200);
        }

        public static Item.Item MakeWaterDrink()
        {
            return Drink.Factory("水", 100);
        }
    }
}

