using System;

namespace Matrix
{
    /// <summary>
    /// Provides class of diagonal matrix
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Provides instance of <see cref="DiagonalMatrix{T}"/>
        /// </summary>
        /// <param name="size">Number rows and colums in matrix</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Provides instance of <see cref="DiagonalMatrix{T}"/>
        /// </summary>
        /// <param name="matrix">Input array</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Checkes is data in array satisfies predetermined structure
        /// </summary>
        /// <param name="inArray">Innput array</param>
        protected override void CheckArray(T[,] inArray)
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (i != j)
                    {
                        if (!this._matrix[i, j].Equals(default(T)))
                        {
                            throw new ArgumentException($"Matrix isn't diagonal matrix");
                        }
                    }
                }
            }
        }
    }
}