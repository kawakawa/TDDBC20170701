using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public enum MoneyType
    {
        Bill,//札
        Coin//コイン
    }


    public class Money
    {
        private readonly int _money;
        private readonly MoneyType _moneyType;

        public Money(int money,MoneyType moneyType)
        {
            _money = money;
            _moneyType = moneyType;
        }
    }
}
