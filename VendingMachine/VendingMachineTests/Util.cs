using System.Linq;
using Item.Items;
using VendingMachine;
using VendingMachine.部位;

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


        public static アイテムRack アイテムRack準備()
        {
            var  アイテムRack = VendingMachine.部位.アイテムRack .Factory();
            アイテムRack.格納アイテム初期化();
            return アイテムRack;
        }


        public static 投入金 投入金準備()
        {
            var 投入金 =  VendingMachine.投入金.Factory();
            投入金.投入金額歴初期化();
            return 投入金;
        }


        public static 売上金 売上金準備()
        {
            var 売上金 = VendingMachine.売上金.Factory();
            売上金.初期化();
            return 売上金;
        }


        public static void アイテムRackにセット(Item.Item アイテム, int 個数)
        {
            var アイテムRack = VendingMachine.部位.アイテムRack.Factory();

            Enumerable.Range(1, 個数).ToList()
                .ForEach(i => アイテムRack.Setアイテム(アイテム));
        }

        public static Item.Item 受取口からアイテム取出し()
        {
            return アイテム受取口
                .Factory()
                .Getアイテム();
        }

        public static 釣銭 釣銭取出し()
        {
            return 釣銭口.Factory().Get釣銭();
        }

        public static 取扱外金 取扱外金取出し()
        {
            return 釣銭口.Factory().Get取扱外金();
        }


    }
}

