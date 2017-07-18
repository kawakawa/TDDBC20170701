using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 売上金額管理
    {
        private static 売上金額管理 _売上金額管理;

        private 売上金額管理()
        {
        }



        public static 売上金額管理 売上金額管理Factory()
        {
            return _売上金額管理 ?? (_売上金額管理 = new 売上金額管理());
        }

        public int GetTotal売上金額()
        {
            return 100;
        }
    }
}
