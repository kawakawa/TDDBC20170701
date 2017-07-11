using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public static class 投入口
    {

        public static void 投入(Money.Money money)
        {
            投入金額.Add投入金(money);
        }
    }
}
