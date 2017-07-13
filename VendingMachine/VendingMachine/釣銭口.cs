﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
    public class 釣銭口
    {

        private static 釣銭口 _釣銭口;


        private readonly 取扱外金 _取扱外金;


        private 釣銭口() {
            //初期化
            _取扱外金 = new 取扱外金();
        }


        public static 釣銭口 釣銭口Factory()
        {
            return _釣銭口?? (_釣銭口 = new 釣銭口());
        }


        public void Add取扱外(Money.Money 投入金)
        {
            _取扱外金.Add(投入金);
        }


        public 取扱外金 Get取扱外金()
        {
            var 返却用取扱外金 = _取扱外金.Clone();
            _取扱外金.初期化();
            return 返却用取扱外金;
        }

    }
}
