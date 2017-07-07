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
        private readonly MoneyType _moneyType;


        public int Value { get; }

        public Money(int money,MoneyType moneyType)
        {
            Value = money;
            _moneyType = moneyType;
        }
    }


    
}
