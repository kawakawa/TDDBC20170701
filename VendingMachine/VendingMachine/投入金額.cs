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
        private readonly List<Money.Money> _投入金額歴;


        private 投入金額()
        {
            _投入金額歴=new List<Money.Money>();
        }



        public static 投入金額 投入金額Factory()
        {
            return _投入金額 ?? (_投入金額 = new 投入金額());
        }


        public int Get合計金額()
        {
            return _投入金額歴.Sum(n=>n.Value);
        }


        public void Add投入金(Money.Money money)
        {
            _投入金額歴.Add(money);
        }


        public 釣銭 払い戻し()
        {
            var 釣銭=new 釣銭(_投入金額歴.ToList());
            初期化();
            return 釣銭;
        }


        public  void 初期化()
        {
            _投入金額歴.Clear();
        }
    }
}
