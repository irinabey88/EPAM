using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    public class CustomIterator<T> : IEnumerator<T>
    {
        public T[] Container;

        private int _position = -1;

        public CustomIterator(T[] container)
        {
            this.Container = container;
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this._position++;
            return (this._position < this.Container.Length);
        }

        public void Reset()
        {
            this._position = -1;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position == Container.Length)
                {
                    throw new InvalidOperationException();
                }

                return Container[_position];
            }
        }

        object IEnumerator.Current => this.Current;
    }

}
