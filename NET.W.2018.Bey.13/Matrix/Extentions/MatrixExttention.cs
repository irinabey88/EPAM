using System;

namespace Matrix.Extentions
{
    public static class MatrixExttention
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> source, SquareMatrix<T> other, Func<T, T, T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (source.Size != other.Size)
            {
                throw new ArgumentNullException($"Matrixs have diffrent size");
            }

            SquareMatrix<T> result = new SquareMatrix<T>(source.Size);

            for (int i = 0; i < source.Size; i++)
            {
                for (int j = 0; j < source.Size; j++)
                {
                    result[i, j] = action(source[i, j], other[i, j]);
                }
            }

            return result;
        }    
    }
}