using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class MoneyKind
    {
        //10円玉
        public static Money Yen10 => new Money(10, MoneyType.コイン);

        //50円玉
        public static Money Yen50 => new Money(50, MoneyType.コイン);

        //100円玉
        public static Money Yen100 => new Money(100, MoneyType.コイン);

        //500円玉
        public static Money Yen500 => new Money(500, MoneyType.コイン);

        //1000円札
        public static Money Yen1000 => new Money(1000, MoneyType.札);



    }
}
