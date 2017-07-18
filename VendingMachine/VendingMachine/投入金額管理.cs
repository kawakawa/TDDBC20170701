using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class 投入金額管理
    {

        private static 投入金額管理 _投入金額管理;

        private readonly List<Money.Money> _投入金額歴;


        private 投入金額管理()
        {
            _投入金額歴=new List<Money.Money>();
        }



        public static 投入金額管理 投入金額Factory()
        {
            return _投入金額管理 ?? (_投入金額管理 = new 投入金額管理());
        }


        public int Get合計金額()
        {
            return _投入金額歴.Sum(n=>n.Value);
        }


        public void Add投入金(Money.Money money)
        {
            _投入金額歴.Add(money);
        }


        public void 払い戻し()
        {
            //釣銭口に釣銭セット
            釣銭口.釣銭口Factory()
                  .Set釣銭(_投入金額歴);

            投入金額歴初期化();
        }


        public  void 投入金額歴初期化()
        {
            _投入金額歴.Clear();
        }


        public 投入金額管理 Set購入金額(int 購入金額)
        {
            //投入金額-購入額
            var 差額値 = _投入金額歴.Sum(n => n.Value) - 購入金額;


            //差額分の金額用意
            投入金額歴初期化();
            if (差額値 != 0)
            {
                var 差額金額 = Money.MoneyKind.Yen10;
                Add投入金(差額金額);
            }


            return this;
        }
    }
}
