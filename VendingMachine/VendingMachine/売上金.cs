namespace VendingMachine
{
    public class 売上金
    {
        private static 売上金 _売上金;

        private int _売上金額;

        private 売上金()
        {
        }

        public void 初期化()
        {
            _売上金額 = 0;
        }


        public static 売上金 売上金額管理Factory()
        {
            return _売上金 ?? (_売上金 = new 売上金());
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
