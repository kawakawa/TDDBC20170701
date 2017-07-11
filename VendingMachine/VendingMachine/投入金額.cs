using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class 投入金額
    {

        private static 投入金額 _投入金額;

        /// <summary>
        /// 投入金額歴
        /// </summary>
        private readonly List<Money.Money> _insertMoneyHistories;


        private 投入金額()
        {
            _insertMoneyHistories=new List<Money.Money>();
        }



        public static 投入金額 投入金額Factory()
        {
            return _投入金額 ?? (_投入金額 = new 投入金額());
        }


        public int Get合計金額()
        {
            return _insertMoneyHistories.Sum(n=>n.Value);
        }


        public void Add投入金(Money.Money money)
        {
            _insertMoneyHistories.Add(money);
        }


        public  void 初期化()
        {
            _insertMoneyHistories.Clear();
        }
    }
}
