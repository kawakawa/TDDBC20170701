using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class 取扱外金
    {

        private readonly List<Money.Money> _取扱外金List;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public 取扱外金()
        {
            _取扱外金List=new List<Money.Money>();
        }
        public 取扱外金(IEnumerable<Money.Money> 取扱外金List):this()
        {
            _取扱外金List.AddRange(取扱外金List);
        }
        


        public void Add(Money.Money money)
        {
            _取扱外金List.Add(money);
        }


        public int Get合計金額()
        {
            return _取扱外金List.Sum(n => n.Value);
        }

        public void 初期化()
        {
            _取扱外金List.Clear();
        }

        public 取扱外金 Clone()
        {
            return new 取扱外金(_取扱外金List);
        }
    }
}
