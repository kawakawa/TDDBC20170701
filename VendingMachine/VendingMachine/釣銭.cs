using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 釣銭
    {

        private readonly List<Money.Money> _釣銭金額;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public 釣銭()
        {
          _釣銭金額=new List<Money.Money>(); 
        }
        public 釣銭(IEnumerable<Money.Money> money)
        {
            _釣銭金額 = money.ToList();
        }

        public IEnumerable<Money.Money> Get釣銭内容()
        {
            return _釣銭金額;
        }

        public int Get合計金額()
        {
            return _釣銭金額.Sum(n=>n.Value);
        }


        public void 初期化()
        {
            _釣銭金額.Clear();
        }

        public 釣銭 Clone()
        {
            return new 釣銭(_釣銭金額);
        }
    }
}
