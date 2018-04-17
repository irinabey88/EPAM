using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Matrix.Interfaces;

namespace Matrix
{
    /// <summary>
    /// Provides base class of square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : IMatrix<T>
    {
        /// <summary>
        /// Inner matrix
        /// </summary>
        private T[,] _matrix;

        /// <summary>
        /// Number of row and colums in matrix
        /// </summary>
        private int _size;

        /// <summary>
        /// Create instance of <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="size">Matrix size</param>
        public SquareMatrix(int size)
        {
            this.Size = size;
            this._matrix = new T[this.Size, this.Size];
        }

        /// <summary>
        /// Create instance of <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="matrix">Input array</param>
        public SquareMatrix(T[,] matrix)
        {
            CheckArray(matrix);

            this.Size = matrix.GetLength(0);
            this._matrix = matrix;
        }

        /// <summary>
        /// Event 
        /// </summary>
        public event EventHandler<ElementChanedEventArgs<T>> ElementChaned;

        /// <summary>
        /// Number of rows, number of colums
        /// </summary>
        public int Size
        {
            get => this._size;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Size matrix can't be less or equal 0");
                }

                this._size = value;
            }
        }


        protected T[,] Matrix
        {
            get => this._matrix;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._matrix = value;
            }
        }
        /// <summary>
        /// Indexator 
        /// </summary>
        /// <param name="i">Number row</param>
        /// <param name="j">Number columc</param>
        /// <returns>Element</returns>
        public T this[int i, int j]
        {
            get 
            {
                CheckIndexes(i, j);

                return this._matrix[i, j];
            }

            set
            {
                CheckIndexes(i, j);
                OnElementChanged(new ElementChanedEventArgs<T>(i, j, this._matrix[i, j], value));

                this._matrix[i, j] = value;
            }
        }

        /// <summary>
        /// Executes when event  <see cref="ElementChaned"/> arises
        /// </summary>
        /// <param name="chanedEventArgs">Object EventArgs for event <see cref="ElementChaned"/></param>
        protected void OnElementChanged(ElementChanedEventArgs<T> chanedEventArgs)
        {
            if (chanedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(chanedEventArgs));
            }

            ElementChaned?.Invoke(this, chanedEventArgs);
        }

        /// <summary>
        /// Checkes is data in array satisfies predetermined structure
        /// </summary>
        /// <param name="inArray">Innput array</param>
        protected virtual void CheckArray(T[,] inArray)
        {
            if (inArray == null)
            {
                throw new ArgumentNullException(nameof(inArray));
            }

            if (inArray.GetLength(0) != inArray.GetLength(1))
            {
                throw new ArgumentException(nameof(inArray));
            }
        }

        private void CheckIndexes(int i, int j)
        {
            if (i < 0 || i >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j < 0 || j >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }
        }
    }
}
