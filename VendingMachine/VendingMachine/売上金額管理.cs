﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class 売上金額管理
    {
        private static 売上金額管理 _売上金額管理;

        private int _売上金額;

        private 売上金額管理()
        {
        }

        public void 初期化()
        {
            _売上金額 = 0;
        }


        public static 売上金額管理 売上金額管理Factory()
        {
            return _売上金額管理 ?? (_売上金額管理 = new 売上金額管理());
        }

        public int GetTotal売上金額()
        {
            return _売上金額;
        }

        public void Add売上金(int price)
        {
            _売上金額 += price;
        }

    }
}
