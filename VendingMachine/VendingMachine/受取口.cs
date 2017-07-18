using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 受取口
    {
        public static Item.Item Getアイテム()
        {
            var coke = Item.Items.Drink.Factory("コーラ", 100);
            return coke;
        }
    }
}
