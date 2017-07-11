using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class 投入金額
    {

        private static List<Money.Money> Money=new List<Money.Money>();



        public static int Get合計金額()
        {
            return Money.Sum(n=>n.Value);
        }


        public static void Add投入金(Money.Money money)
        {
            Money.Add(money);
        }


        public static void 初期化()
        {
            Money.Clear();
        }
    }
}
