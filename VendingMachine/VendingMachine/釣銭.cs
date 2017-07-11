using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 釣銭
    {

        private readonly IEnumerable<Money.Money> _投入金額歴;

        public 釣銭(IEnumerable<Money.Money> 投入金額歴)
        {
            _投入金額歴 = 投入金額歴;
        }


        public int Get合計金額()
        {
            return _投入金額歴.Sum(n=>n.Value);
        }
    }
}
