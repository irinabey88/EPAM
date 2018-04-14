using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    /// <summary>
    /// Provides custom queue
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class CustomQueue<T> : IEnumerable
    {
        private const int DEFAULT_SIZE = 8;

        private const int INCREASE_VALUE = 2;

        private const int HEAD = 0;                    

        private T[] _container;

        private int _count;

        private int _head = HEAD;

        private int _end;

        private int _capacity;

        public CustomQueue()
        {
            this._container = new T[DEFAULT_SIZE];
            this._capacity = DEFAULT_SIZE;
            this._count = 0;
            this._end = 0;
        }

        public object SyncRoot { get; }

        public bool IsSynchronized { get; }

        public int Count => this._count;

        public int Capacity => this._capacity;

        public IEnumerator GetEnumerator()
        {
            return this._container.GetEnumerator();
        }

        /// <summary>
        /// Copies all elements of queue to array 
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="index">Start index fo copy</param>
        /// <exception cref="ArgumentNullException">Array is null vallue</exception>
        /// <exception cref="ArgumentException">Array length is 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Index les than 0</exception>
        /// <exception cref="InvalidOperationException">Index less tan array length</exception>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Array {nameof(array)} length is 0");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException($"Index {nameof(index)} ");
            }

            if (array.Length - 1 < index)
            {
                throw new InvalidOperationException($"Array {nameof(array)} length is less than input index: {index}");
            }

            if ((array.Length - index) < this._count)
            {
                throw new ArgumentException($"There are not enough elements in array {nameof(array)} for copy");
            }

            var custedArray = array as T[] ?? throw new InvalidCastException(nameof(array));
            Array.Copy(this._container, _head, array, index, this._count);
        }

        public void Clear()
        {
            this._container = new T[DEFAULT_SIZE];
            this._count = 0;
            this._capacity = DEFAULT_SIZE;
        }

        /// <summary>
        /// Check are there such <see cref="item"/> in queue
        /// </summary>
        /// <param name="item">Element to find</param>
        /// <returns><value>True - if element is find</value>
        /// <value>False - otherwise</value></returns>
        /// <exception cref="ArgumentNullException">Input data is null</exception>
        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(item))
                {
                    return true;
                }                
            }

            return false;
        }

        /// <summary>
        /// Remove element from the beginnig of queue
        /// </summary>
        /// <returns>Changed queue</returns>
        /// <exception cref="InvalidOperationException">Operation with empty queue</exception>
        public T Deque()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var deletedElement = this._container[_head];

            T[] changedQueue = new T[this._capacity];
            Array.Copy(this._container, 1, changedQueue, 0, this._capacity - 1);
            this._container = changedQueue;
            this._count--;

            return deletedElement;
        }

        /// <summary>
        /// Adds elements to the end of queue
        /// </summary>
        /// <param name="item">Added element</param>
        /// <exception cref="ArgumentNullException">Input data value is null</exception>
        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this._container[this._end] = item;
            this._end++;
            this._count++;

            if (_end == this._capacity)
            {
                ChangeSizeQueue();
            }
        }

        /// <summary>
        /// Gets the first element from the queue without removing 
        /// </summary>
        /// <returns>First element</returns>
        /// <exception cref="InvalidOperationException">Operation with empty queue</exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return this._container[_head];
        }

        /// <summary>
        /// Gets array representation of queue
        /// </summary>
        /// <returns>Array of queue elements</returns>
        public T[] ToArray()
        {
            T[] copyArray = new T[this._count];
            Array.Copy(this._container, copyArray, this._count);

            return copyArray;
        }

        /// <summary>
        /// Increasses the array size
        /// </summary>
        private void ChangeSizeQueue()
        {
            this._capacity *= INCREASE_VALUE;
            T[] changedQueue = new T[this._capacity];
            Array.Copy(this._container, changedQueue, this._container.Length);
            this._container = changedQueue;
        }
    }
}
