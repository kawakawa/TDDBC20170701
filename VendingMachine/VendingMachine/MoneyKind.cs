using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MoneyKind
    {
        //10円玉
        public Money Money10 => new Money(10,MoneyType.Coin);

        //50円玉
        public Money Money50 => new Money(50, MoneyType.Coin);

        //100円玉
        public Money Money100 => new Money(100, MoneyType.Coin);

        //500円玉
        public Money Money500 => new Money(500, MoneyType.Coin);

        //1000円札
        public Money Money1000 => new Money(500, MoneyType.Bill);

    }

}
