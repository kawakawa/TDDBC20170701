using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 投入金額
    {

        private static List<Money.Money> _money=new List<Money.Money>();



        public static int Get合計金額()
        {
            return 投入金額._money.Sum(n=>n.Value);
        }


        public static void Add投入金(Money.Money money)
        {
            投入金額._money.Add(money);
        }


        public static void 投入金額Clear()
        {
            _money.Clear();
        }
    }
}
