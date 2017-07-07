using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 投入金額
    {
        public static int Get合計金額()
        {
            return 投入金額.money.Value;
        }


        private static Money money;
        public static void Add投入金(Money money)
        {
            投入金額.money = money;
        }
    }
}
