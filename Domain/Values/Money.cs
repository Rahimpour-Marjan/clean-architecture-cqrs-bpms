// مثال
using Domain.Common;

namespace Domain.Values
{
    public class Money : ValueObject
    {
        protected Money()
        {

        }
        public Money(int value)
        {
            if (value >= 0)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("پول نمی تواند کمتر از 0 باشد!");
            }
        }
        public int Value { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
