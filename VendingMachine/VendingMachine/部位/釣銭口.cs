using System.Collections.Generic;

namespace VendingMachine.部位
{
    public class 釣銭口
    {

        private static 釣銭口 _釣銭口;


        private 釣銭 _釣銭;
        private readonly 取扱外金 _取扱外金;

        private 釣銭口() {
            //初期化
            _釣銭=new 釣銭();
            _取扱外金 = new 取扱外金();
        }


        public static 釣銭口 Factory()
        {
            return _釣銭口?? (_釣銭口 = new 釣銭口());
        }


        public void Add取扱外金(Money.Money 投入金)
        {
            _取扱外金.Add(投入金);
        }


        public void Set釣銭(IEnumerable<Money.Money> money)
        {
            _釣銭 = new 釣銭(money);
        }

        public 釣銭 Get釣銭()
        {
            var 返却用釣銭 = _釣銭.Clone();
            _釣銭.初期化();
            return 返却用釣銭;
        }

        public 取扱外金 Get取扱外金()
        {
            var 返却用取扱外金 = _取扱外金.Clone();
            _取扱外金.初期化();
            return 返却用取扱外金;
        }



    }
}
