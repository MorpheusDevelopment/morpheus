
namespace Objects.Generics
{
    public struct Id<T>
    {
        private readonly int _value;

        public Id(int value)
        {
            _value = value;
        }

        public static implicit operator int(Id<T> id) => id._value;

        public static explicit operator Id<T>(int value) => new Id<T>(value);
    }
}
