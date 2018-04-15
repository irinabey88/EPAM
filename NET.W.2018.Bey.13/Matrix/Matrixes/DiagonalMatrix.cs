using System;

namespace Matrix
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
        }

        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
        }

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