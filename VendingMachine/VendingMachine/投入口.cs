using System;
using System.CodeDom;
using System.Dynamic;

namespace VendingMachine
{
    public static class 投入口
    {

        private static 投入金額 _投入金額=null;

        public static void Set投入金額(投入金額 投入金額)
        {
            _投入金額 = 投入金額;
        }


        public static void 投入(Money.Money money)
        {
            if(_投入金額==null)
                throw new NullReferenceException(nameof(_投入金額));

            _投入金額.Add投入金(money);
        }
    }
}
