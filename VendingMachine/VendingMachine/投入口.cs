using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Rules;

namespace VendingMachine
{
    public class 投入口
    {
        private static 投入口 _投入口;

        private readonly 投入金額 _投入金額;

        private List<Money.Money> _取扱外金;



        private 投入口(投入金額 投入金額)
        {
            _投入金額 = 投入金額 ?? throw new ArgumentNullException(nameof(投入金額));

            //初期化
            _取扱外金 =new List<Money.Money>();
        }

        public static 投入口 投入口Factory(投入金額 投入金額)
        {
            return _投入口 ?? (_投入口 = new 投入口(投入金額));
        }


        public void 投入(Money.Money 投入金)
        {
            if (取扱硬貨.Is取扱対象硬貨(投入金)==false)
            {
                _取扱外金.Add(投入金);
                return;
            }

            _投入金額.Add投入金(投入金);
        }


        public IEnumerable<Money.Money> Get取扱外金()
        {
            if(_取扱外金==null)
                throw new NullReferenceException(nameof(_取扱外金));

            var 返却用取扱外金 = _取扱外金.ToList();
            _取扱外金.Clear();

            return 返却用取扱外金;
        }
    }
}
