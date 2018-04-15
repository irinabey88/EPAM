using System;

namespace Matrix
{
    public sealed class SimmetricalMatrix<T> : SquareMatrix<T>
    {
        public SimmetricalMatrix(int size) : base(size)
        {
        }

        public SimmetricalMatrix(T[,] matrix) : base(matrix)
        {
        }

        protected override void CheckArray(T[,] inArray)
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (!this._matrix[i, j].Equals(this._matrix[j,i]))
                    {
                        throw new ArgumentException($"Matrix isn't simmetrical matrix");
                    }
                }
            }
        }
    }
}