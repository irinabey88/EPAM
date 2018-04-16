using System;

namespace Matrix
{
    /// <summary>
    /// Provides class of simmetrical matrix
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public sealed class SimmetricalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Provides instance of <see cref="SimmetricalMatrix{T}"/>
        /// </summary>
        /// <param name="size">Number rows and colums in matrix</param>
        public SimmetricalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Provides instance of <see cref="SimmetricalMatrix{T}"/>
        /// </summary>
        /// <param name="matrix">Input array</param>
        public SimmetricalMatrix(T[,] matrix) : base(matrix)
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
                    if (!this._matrix[i, j].Equals(this._matrix[j, i]))
                    {
                        throw new ArgumentException($"Matrix isn't simmetrical matrix");
                    }
                }
            }
        }
    }
}