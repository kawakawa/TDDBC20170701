using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class MoneyKind
    {
        //1円玉
        public static Money Yen1 = new Money(1,MoneyType.コイン);

        //5円玉
        public static Money Yen5 = new Money(5,MoneyType.コイン);

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

        //2000円札
        public static Money Yen2000=> new Money(2000,MoneyType.札);

        //5000円札
        public static Money Yen5000 => new Money(5000,MoneyType.札);

        //一万円
        public static  Money Yen10000 => new Money(10000,MoneyType.札);



        public static IEnumerable<Money> GetList()
        {
            yield return Yen1;
            yield return Yen5;
            yield return Yen10;
            yield return Yen50;
            yield return Yen100;
            yield return Yen500;
            yield return Yen1000;
            yield return Yen2000;
            yield return Yen5000;
            yield return Yen10000;
        }
    }
}
