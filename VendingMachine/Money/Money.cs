namespace Money
{
    public class Money
    {
        private readonly MoneyType _moneyType;


        public int Value { get; }

        public Money(int money, MoneyType moneyType)
        {
            Value = money;
            _moneyType = moneyType;
        }



        //objと自分自身が等価のときはtrueを返す
        public override bool Equals(object obj)
        {
            var money = obj as Money;

            return Value == money?.Value;
        }

        //Equalsがtrueを返すときに同じ値を返す
        public override int GetHashCode()
        {
            return Value;
        }


        public static bool operator ==(Money a, Money b)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }
        
    }
}
