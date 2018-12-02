using System;

namespace SystemFramework.Events
{
    public class ValueEventArgs<T> : EventArgs
    {
        public T Value { get; private set; }

        public ValueEventArgs(T value)
            :base()
        {
            Value = value;
        }
    }

    public class IntEventArgs : ValueEventArgs<int>
    {
        public IntEventArgs(int value)
            :base(value)
        { }
    }
}
