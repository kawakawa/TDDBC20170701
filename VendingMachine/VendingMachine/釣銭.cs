using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 釣銭
    {

        private readonly List<Money.Money> _投入金額歴;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public 釣銭()
        {
          _投入金額歴=new List<Money.Money>(); 
        }
        public 釣銭(IEnumerable<Money.Money> 投入金額歴)
        {
            _投入金額歴 = 投入金額歴.ToList();
        }


        public int Get合計金額()
        {
            return _投入金額歴.Sum(n=>n.Value);
        }


        public void 初期化()
        {
            _投入金額歴.Clear();
        }

        public 釣銭 Clone()
        {
            return new 釣銭(_投入金額歴);
        }
    }
}
