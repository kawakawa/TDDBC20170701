using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Rules
{
    public static class 取扱硬貨
    {
        /// <summary>
        /// 自販機取扱硬貨の判定
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool Is取扱対象硬貨(Money.Money money)
        {
            return money == Money.MoneyKind.Yen10
                   ||
                   money == Money.MoneyKind.Yen50
                   ||
                   money == Money.MoneyKind.Yen100
                   ||
                   money == Money.MoneyKind.Yen500
                   ||
                   money == Money.MoneyKind.Yen1000;
        }
    }
}
