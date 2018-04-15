using System;

namespace Matrix
{
    public class ElementEventArgs<T> : EventArgs
    {
        private int _i;

        private int _j;

        public ElementEventArgs(int i, int j, T oldValue, T newValue)
        {
            this.I = i;
            this.J = j;
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }

        public int I
        {
            get => this._i;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Index i can't be negative");
                }
            }
        }

        public int J
        {
            get => this._j;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Index i can't be negative");
                }
            }
        }

        public T OldValue { get; }

        public T NewValue { get; }
    }
}